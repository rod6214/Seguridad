using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;
using Data.Usuarios.Entities;
using Model.Usuarios.Usuarios;
using Model.Usuarios.Sesiones;

namespace Data.Usuarios.Mappers
{
    internal class UsuarioMapper : IMapper<UsuarioModel, Usuario>
    {
        public void Map(UsuarioModel src, Usuario dest)
        {
            dest.id = src.Id;
            dest.name = src.Name;
            dest.pass = src.Pass;
            dest.role = (byte)src.Role;
        }

        public Usuario MapNew(UsuarioModel src)
        {
            return new Usuario
            {
                id = src.Id,
                name = src.Name,
                pass = src.Pass,
                role = (byte)src.Role,
            };
        }
    }
}
