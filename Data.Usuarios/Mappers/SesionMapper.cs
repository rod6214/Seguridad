using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;
using Model.Usuarios.Sesiones;
using Data.Usuarios.Entities;

namespace Data.Usuarios.Mappers
{
    internal class SesionMapper : IMapper<SesionModel, Sesion>
    {
        public void Map(SesionModel src, Sesion dest)
        {
            dest.id = src.Id;
            dest.key = src.Key;
            dest.value = src.Value;
            dest.initTime = src.InitTime;
            dest.duration = src.Duration;
            dest.Usuario_id = src.UsuarioId;
        }
        public Sesion MapNew(SesionModel src)
        {
            return new Sesion
            {
                id = src.Id,
                key = src.Key,
                value = src.Value,
                duration = src.Duration,
                initTime = src.InitTime,
                Usuario_id = src.UsuarioId
            };
        }
    }
}
