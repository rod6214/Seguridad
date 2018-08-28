using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;
using Newtonsoft.Json;

namespace Model.Usuarios.Usuarios
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UsuarioModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Pass")]
        public string Pass { get; set; }
        [JsonProperty("Role")]
        public AccountAccess Role { get; set; }
    }
}
