using Xunit;
using TransacaoFinanceira.Repository;
using TransacaoFinanceira.Models;
using System.Linq;

namespace AcessoDadosTests
{
    public class AcessoDadosTests
    {
        [Fact]
        public void GetSaldo_DeveRetornarSaldoCorreto_QuandoContaExiste()
        {
            var acessoDados = new AcessoDados();

            var saldo = acessoDados.GetSaldo(938485762);

            Assert.NotNull(saldo); 
            Assert.Equal(180, saldo!.Saldo); 
        }

        [Fact]
        public void GetSaldo_DeveRetornarNull_QuandoContaNaoExiste()
        {
            var acessoDados = new AcessoDados();

            var saldo = acessoDados.GetSaldo(999999999);

            Assert.Null(saldo);
        }

        [Fact]
        public void ObterTodosSaldos_DeveRetornarTodasContas()
        {
            var acessoDados = new AcessoDados();

            var todos = acessoDados.ObterTodosSaldos();

            Assert.Equal(9, todos.Count()); 
        }
    }
}