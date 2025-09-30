using System;
using System.Collections.Generic;
using TransacaoFinanceira.Repository;
using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Services
{
    public class TransacaoFinanceiraService : AcessoDados, ITransacaoFinanceira
    {
        public void Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor)
        {
            ContaSaldo? origem = GetSaldo(contaOrigem);
            ContaSaldo? destino = GetSaldo(contaDestino);

            if (origem == null || destino == null)
            {
                Console.WriteLine("Transação {0} inválida: conta inexistente.", correlationId);
                return;
            }

            if (origem.Saldo < valor)
            {
                Console.WriteLine("Transação {0} foi cancelada por falta de saldo. " +
                                  "Solicitacao de Transacao: {2} Saldo Atual: {1}", correlationId, origem.Saldo, valor);
                return;
            }

            origem.Saldo -= valor;
            destino.Saldo += valor;

            Console.WriteLine(" Transação {0} foi efetivada com sucesso! " +
                              "Novos saldos: Conta Origem:{1} Saldo:{3} | Conta Destino: {2} Saldo: {4}", correlationId, contaOrigem, contaDestino, origem.Saldo, destino.Saldo);
        }

        public new IEnumerable<ContaSaldo> ObterTodosSaldos()
        {
            return base.ObterTodosSaldos();
        }
    }
}
