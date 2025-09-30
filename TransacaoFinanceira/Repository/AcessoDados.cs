using System.Collections.Generic;
using System.Linq;
using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Repository
{
    public class AcessoDados
    {
        protected readonly List<ContaSaldo> tabelaSaldos;

        public AcessoDados()
        {
            tabelaSaldos = new List<ContaSaldo>
            {
                new ContaSaldo(938485762, 180),
                new ContaSaldo(347586970, 1200),
                new ContaSaldo(2147483649, 0),
                new ContaSaldo(675869708, 4900),
                new ContaSaldo(238596054, 478),
                new ContaSaldo(573659065, 787),
                new ContaSaldo(210385733, 10),
                new ContaSaldo(674038564, 400),
                new ContaSaldo(563856300, 1200)
            };
        }

        public ContaSaldo GetSaldo(long contaId)
        {
            return tabelaSaldos.FirstOrDefault(x => x.Conta == contaId);
        }

        public IEnumerable<ContaSaldo> ObterTodosSaldos()
        {
            return tabelaSaldos;
        }
    }
}
