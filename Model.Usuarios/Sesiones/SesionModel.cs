using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model.Usuarios.Sesiones
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SesionModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Key")]
        public string Key { get; set; }
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("Duration")]
        public long Duration { get; set; }
        [JsonProperty("InitTime")]
        public DateTime InitTime { get; set; }
        [JsonProperty("UsuarioId")]
        public int UsuarioId { get; set; }
    }
}
