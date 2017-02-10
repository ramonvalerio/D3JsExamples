using System.Collections.Generic;

namespace D3JsExamples.WPF.dto
{
    public class ChartStackedBarDTO
    {
        public string x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int a { get; set; }
        public static List<ChartStackedBarDTO> GetData()
        {
            var resultado = new List<ChartStackedBarDTO>();

            for (int i = 0; i < 30; i++)
            {
                var dto = new ChartStackedBarDTO();
                dto.x = string.Format("2011 Q{0}", i + 1);
                dto.y = i + 1;
                dto.z = i + 2;
                dto.a = i + 3;

                resultado.Add(dto);
            }

            return resultado;
        }
    }
}