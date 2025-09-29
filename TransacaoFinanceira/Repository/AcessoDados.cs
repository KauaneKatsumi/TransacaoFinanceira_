using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Repository
{
    public class AcessoDados
    {
         private List<ContasSaldo> TABELA_SALDOS;
        private readonly object _lockObject = new object(); // Lock para concorrência

        public AcessoDados()
        {
            TABELA_SALDOS = new List<ContasSaldo>
            {
                new ContasSaldo(938485762, 180),
                new ContasSaldo(347586970, 1200),
                new ContasSaldo(2147483649, 0),
                new ContasSaldo(675869708, 4900),
                new ContasSaldo(238596054, 478),
                new ContasSaldo(573659065, 787),
                new ContasSaldo(210385733, 10),
                new ContasSaldo(674038564, 400),
                new ContasSaldo(563856300, 1200)
            };
        }

        public ContasSaldo GetSaldo(long id)
        {
            lock (_lockObject) //Thread-safe
            {
                return TABELA_SALDOS.Find(x => x.Conta == id);
            }
        }

        public bool Atualizar(ContasSaldo dado)
        {
            lock (_lockObject) //Thread-safe
            {
                try
                {
                    var index = TABELA_SALDOS.FindIndex(x => x.Conta == dado.Conta);
                    if (index >= 0)
                    {
                        TABELA_SALDOS[index] = dado;
                    }
                    else
                    {
                        TABELA_SALDOS.Add(dado);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao atualizar conta {dado.Conta}: {e.Message}");
                    return false;
                }
            }
        }  
    }
}