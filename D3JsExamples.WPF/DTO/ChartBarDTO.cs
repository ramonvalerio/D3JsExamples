using System.Collections.Generic;

namespace D3JsExamples.WPF.DTO
{
    public class ChartBarDTO
    {
        public string letter { get; set; }

        public double frequency { get; set; }

        public static List<ChartBarDTO> GetData()
        {
            var resultado = new List<ChartBarDTO>();

            var letras = new string[]{"A", "B", "C"};

            for (int i = 0; i < letras.Length; i++)
            {
                var dto = new ChartBarDTO();
                dto.letter = letras[i];
                dto.frequency = 08167 + i;

                resultado.Add(dto);
            }

            return resultado;
        }
    }
}