using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Usuarios.Usuarios;
using Util.Interfaces;
using Data.Usuarios.Entities;
using Util.Enums;

namespace Data.Usuarios.Mappers
{
    internal class UsuarioModelMapper : IMapper<Usuario, UsuarioModel>
    {
        public void Map(Usuario src, UsuarioModel dest)
        {
            dest.Id = src.id;
            dest.Name = src.name;
            dest.Pass = src.pass;
            dest.Role = (AccountAccess)src.role;
        }

        public UsuarioModel MapNew(Usuario src)
        {
            return new UsuarioModel
            {
                Id = src.id,
                Name = src.name,
                Pass = src.pass,
                Role = (AccountAccess)src.role
            };
        }
    }
}
