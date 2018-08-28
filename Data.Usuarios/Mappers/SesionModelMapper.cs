using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;
using Data.Usuarios.Entities;
using Model.Usuarios.Sesiones;

namespace Data.Usuarios.Mappers
{
    internal class SesionModelMapper : IMapper<Sesion, SesionModel>
    {
        public void Map(Sesion src, SesionModel dest)
        {
            dest.Id = src.id;
            dest.Key = src.key;
            dest.Value = src.value;
            dest.InitTime = src.initTime;
            dest.Duration = src.duration;
            dest.UsuarioId = src.Usuario_id;
        }

        public SesionModel MapNew(Sesion src)
        {
            return new SesionModel
            {
                Id = src.id,
                Key = src.key,
                Value = src.value,
                Duration = src.duration,
                UsuarioId = src.Usuario_id,
                InitTime = src.initTime
            };
        }
    }
}
