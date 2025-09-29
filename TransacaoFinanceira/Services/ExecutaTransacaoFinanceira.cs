using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Services
{
    public class ExecutaTransacaoFinanceira : Repository.AcessoDados
    {
        // Lock estático - compartilhado por TODAS as instâncias
        private static readonly object _globalLock = new object();

        public void Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor)
        {
            // Bloqueio Global para garantir consistência
            lock (_globalLock)
            {
                try
                {
                    var contaSaldoOrigem = GetSaldo(contaOrigem);
                    if (contaSaldoOrigem == null)
                    {
                        Console.WriteLine($"Transacao {correlationId} cancelada - conta origem {contaOrigem} não encontrada");
                        return;
                    }

                    if (contaSaldoOrigem.Saldo < valor)
                    {
                        Console.WriteLine($"Transacao {correlationId} cancelada por falta de saldo. Saldo: {contaSaldoOrigem.Saldo}, Valor: {valor}");
                        return;
                    }

                    var contaSaldoDestino = GetSaldo(contaDestino);
                    if (contaSaldoDestino == null)
                    {
                        Console.WriteLine($"Transacao {correlationId} cancelada - conta destino {contaDestino} não encontrada");
                        return;
                    }

                    // Realizar a transferência
                    contaSaldoOrigem.Saldo -= valor;
                    contaSaldoDestino.Saldo += valor;

                    // Atualizar saldos no "banco de dados"
                    Atualizar(contaSaldoOrigem);
                    Atualizar(contaSaldoDestino);

                    Console.WriteLine($"Transacao {correlationId} efetivada! Novos saldos: Origem: {contaSaldoOrigem.Saldo} | Destino: {contaSaldoDestino.Saldo}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO Transacao {correlationId}: {ex.Message}");
                }
            }
        }
    }
}