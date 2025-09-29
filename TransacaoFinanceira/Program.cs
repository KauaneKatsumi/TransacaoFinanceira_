using System;
using System.Collections.Generic;
using System.Threading.Tasks;


//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {

        static void Main(string[] args)
        {
            var TRANSACOES = new[] { new {correlation_id= 1,datetime="09/09/2023 14:15:00", conta_origem= 938485762L, conta_destino= 2147483649L, VALOR= 150},
                                     new {correlation_id= 2,datetime="09/09/2023 14:15:05", conta_origem= 2147483649L, conta_destino= 210385733L, VALOR= 149},
                                     new {correlation_id= 3,datetime="09/09/2023 14:15:29", conta_origem= 347586970L, conta_destino= 238596054L, VALOR= 1100},
                                     new {correlation_id= 4,datetime="09/09/2023 14:17:00", conta_origem= 675869708L, conta_destino= 210385733L, VALOR= 5300},
                                     new {correlation_id= 5,datetime="09/09/2023 14:18:00", conta_origem= 238596054L, conta_destino= 674038564L, VALOR= 1489},
                                     new {correlation_id= 6,datetime="09/09/2023 14:18:20", conta_origem= 573659065L, conta_destino= 563856300L, VALOR= 49},
                                     new {correlation_id= 7,datetime="09/09/2023 14:19:00", conta_origem= 938485762L, conta_destino= 2147483649L, VALOR= 44},
                                     new {correlation_id= 8,datetime="09/09/2023 14:19:01", conta_origem= 573659065L, conta_destino= 675869708L, VALOR= 150},

            };

            Services.ExecutaTransacaoFinanceira executor = new Services.ExecutaTransacaoFinanceira();
            // Usar SemaphoreSlim para controlar concorrência
            var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };

            Parallel.ForEach(TRANSACOES, item =>
            {
                executor.Transferir(item.correlation_id, item.conta_origem, item.conta_destino, item.VALOR);
            });

        }
    }
}