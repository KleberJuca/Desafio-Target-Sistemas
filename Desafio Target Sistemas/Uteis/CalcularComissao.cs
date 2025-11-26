using System.Drawing;

namespace Desafio_Target_Sistemas.Uteis
{
    public class CalcularComissao
    {
        public static decimal Calcular(decimal valorVenda)
        {
            if (valorVenda < 100m)
                return 0m;

            if (valorVenda < 500m)
                return valorVenda * 0.01m;

            return valorVenda * 0.05m;
        }
    }
}
