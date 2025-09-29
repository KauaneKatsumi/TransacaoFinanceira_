using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Repository
{
    public class ContasSaldo
    {
        public ContasSaldo(long conta, decimal valor)
        {
            this.Conta = conta;
            this.Saldo = valor;
        }
        public long Conta { get; set; }
        public decimal Saldo { get; set; }
        
    }
}