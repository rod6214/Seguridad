using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Usuarios.Services.Usuarios;
using Newtonsoft.Json;
using Model.Usuarios.Usuarios;
using Util.Enums;

namespace Data.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UsuarioService usrServ = new UsuarioService();
            UsuarioModel usuario = new UsuarioModel
            {
                Id = 0,
                Name = "rod6232",
                Pass = "123458",
                Role = AccountAccess.ADMIN
            };
            string usuarioJson = JsonConvert.SerializeObject(usuario);
            //UsuarioModel usuarioResult = JsonConvert.DeserializeObject<UsuarioModel>("cdknck cdjnjcn");
            //var result = usrServ.Create(usuarioJson);
            //var result = usrServ.Update(usuarioJson);
            var result = usrServ.GetById(3);
        }
    }
}
