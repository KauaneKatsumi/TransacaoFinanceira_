using Xunit;
using TransacaoFinanceira.Services;
using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Tests
{
    public class TransacaoFinanceiraServiceTests
    {
        [Fact]
        public void Transferir_DeveTransferirValorQuandoSaldoSuficiente()
        {
            var service = new TransacaoFinanceiraService();
            var origemAntes = service.GetSaldo(938485762)!.Saldo;
            var destinoAntes = service.GetSaldo(2147483649)!.Saldo;
            decimal valor = 50m;

            service.Transferir(1, 938485762, 2147483649, valor);

            Assert.Equal(origemAntes - valor, service.GetSaldo(938485762)!.Saldo);
            Assert.Equal(destinoAntes + valor, service.GetSaldo(2147483649)!.Saldo);
        }

        [Fact]
        public void Transferir_NaoTransfereQuandoSaldoInsuficiente()
        {

            var service = new TransacaoFinanceiraService();
            var origemAntes = service.GetSaldo(210385733)!.Saldo;
            var destinoAntes = service.GetSaldo(2147483649)!.Saldo;
            decimal valor = 100m; 

            service.Transferir(2, 210385733, 2147483649, valor);

            Assert.Equal(origemAntes, service.GetSaldo(210385733)!.Saldo);
            Assert.Equal(destinoAntes, service.GetSaldo(2147483649)!.Saldo);
        }

        [Fact]
        public void Transferir_NaoTransfereQuandoContaInexistente()
        {

            var service = new TransacaoFinanceiraService();
            var destinoAntes = service.GetSaldo(2147483649)!.Saldo;
            decimal valor = 10m;

            service.Transferir(3, 999999999, 2147483649, valor); 

            Assert.Null(service.GetSaldo(999999999));
            Assert.Equal(destinoAntes, service.GetSaldo(2147483649)!.Saldo);
        }
    }
}