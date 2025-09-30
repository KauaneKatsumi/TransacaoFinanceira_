using System;
using System.Linq;
using System.Collections.Generic;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Services;

namespace TransacaoFinanceira
{
    class Program
    {
        static void Main(string[] args)
        {
            var transacoes = new[]
            {
                new { CorrelationId = 1, DateTime = DateTime.Parse("09/09/2023 14:15:00"), ContaOrigem = 938485762L, ContaDestino = 2147483649L, Valor = 150m },
                new { CorrelationId = 2, DateTime = DateTime.Parse("09/09/2023 14:15:05"), ContaOrigem = 2147483649L, ContaDestino = 210385733L, Valor = 149m },
                new { CorrelationId = 3, DateTime = DateTime.Parse("09/09/2023 14:15:29"), ContaOrigem = 347586970L, ContaDestino = 238596054L, Valor = 1100m },
                new { CorrelationId = 4, DateTime = DateTime.Parse("09/09/2023 14:17:00"), ContaOrigem = 675869708L, ContaDestino = 210385733L, Valor = 5300m },
                new { CorrelationId = 5, DateTime = DateTime.Parse("09/09/2023 14:18:00"), ContaOrigem = 238596054L, ContaDestino = 674038564L, Valor = 1489m },
                new { CorrelationId = 6, DateTime = DateTime.Parse("09/09/2023 14:18:20"), ContaOrigem = 573659065L, ContaDestino = 563856300L, Valor = 49m },
                new { CorrelationId = 7, DateTime = DateTime.Parse("09/09/2023 14:19:00"), ContaOrigem = 938485762L, ContaDestino = 2147483649L, Valor = 44m },
                new { CorrelationId = 8, DateTime = DateTime.Parse("09/09/2023 14:19:01"), ContaOrigem = 573659065L, ContaDestino = 675869708L, Valor = 150m }
            };

            ITransacaoFinanceira executor = new TransacaoFinanceiraService();

            foreach (var item in transacoes.OrderBy(t => t.DateTime))
            {
                executor.Transferir(item.CorrelationId, item.ContaOrigem, item.ContaDestino, item.Valor);
            }

            Console.WriteLine("\n--- Resumo das Transacoes ---");
            foreach (var saldo in executor.ObterTodosSaldos())
            {
                Console.WriteLine($"Conta: {saldo.Conta}, Saldo: {saldo.Saldo}");
            }
        }
    }
}
