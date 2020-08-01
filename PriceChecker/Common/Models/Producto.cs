using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Producto
    {
        [JsonProperty("codArt")]
        public string CodArt { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("precio")]
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"{this.Descripcion} {this.Precio:C2}";
        }
    }
}
