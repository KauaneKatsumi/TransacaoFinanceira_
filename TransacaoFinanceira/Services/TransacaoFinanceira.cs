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
            var origem = GetSaldo(contaOrigem);
            var destino = GetSaldo(contaDestino);

            if (origem == null || destino == null)
            {
                Console.WriteLine($"Transação {correlationId} inválida: conta inexistente.");
                return;
            }

            if (origem.Saldo < valor)
            {
                Console.WriteLine($"Transação {correlationId} cancelada por falta de saldo.");
                return;
            }

            origem.Saldo -= valor;
            destino.Saldo += valor;

            Console.WriteLine($"Transação {correlationId} concluída com sucesso! " +
                              $"Saldo origem: {origem.Saldo} | Saldo destino: {destino.Saldo}");
        }

        public IEnumerable<ContaSaldo> ObterTodosSaldos()
        {
            return base.ObterTodosSaldos();
        }
    }
}
