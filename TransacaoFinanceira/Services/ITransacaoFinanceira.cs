using System;
using System.Collections.Generic;
using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Services
{
    public interface ITransacaoFinanceira
    {
        void Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor);
        IEnumerable<ContaSaldo> ObterTodosSaldos();
    }
}
