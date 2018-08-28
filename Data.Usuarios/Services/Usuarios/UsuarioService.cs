using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Interfaces;
using Util.Converters;
using Data.Usuarios.Entities;
using Model.Usuarios.Usuarios;
using Data.Usuarios.Mappers;
using Newtonsoft.Json;
using Data.Usuarios.Services.Sesiones;
using Model.Usuarios.Sesiones;

namespace Data.Usuarios.Services.Usuarios
{
    public class UsuarioService
    {
        public const string USUARIO_NO_EXISTE = "El usuario no existe";
        private UsuarioModelMapper _usrModelMapper = new UsuarioModelMapper();
        private UsuarioMapper _usrMapper = new UsuarioMapper();
        private SesionModelMapper _sesModelMapper = new SesionModelMapper();
        private SesionMapper _sesMapper = new SesionMapper();

        public string GetAll()
        {
            using (var db = new seguridadEntities())
            {
                List<UsuarioModel> users = new List<UsuarioModel>();
                foreach (var user in db.Usuario)
                    users.Add(_usrModelMapper.MapNew(user));
                return JsonConvert.SerializeObject(users, Formatting.Indented);
            }
        }
        public string Create(string usuariojson)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    UsuarioModel usrModel = JsonConvert.DeserializeObject<UsuarioModel>(usuariojson);
                    if (!GetByName(usrModel.Name).Equals(USUARIO_NO_EXISTE))
                        throw new Exception("El usuario ya existe");
                    Usuario usr = _usrMapper.MapNew(usrModel);
                    db.Usuario.Add(usr);
                    db.SaveChanges();
                    return string.Empty;
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(string usuariojson)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    UsuarioModel usrModel = JsonConvert.DeserializeObject<UsuarioModel>(usuariojson);
                    var usr = db.Usuario?.Where(x => x.name.Equals(usrModel.Name))?.FirstOrDefault();
                    if (usr != null)
                    {
                        usrModel.Id = usr.id;
                        _usrMapper.Map(usrModel, usr);
                        db.SaveChanges();
                        return string.Empty;
                    }
                    else
                        throw new Exception("El usuario no existe");
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetByName(string name)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    var usr = db.Usuario?.Where(x => x.name.Equals(name))?.FirstOrDefault();
                    if (usr != null)
                        return JsonConvert.SerializeObject(_usrModelMapper.MapNew(usr));
                    throw new Exception(USUARIO_NO_EXISTE);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetById(int id)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    var usr = db.Usuario?.Where(x => x.id == id)?.FirstOrDefault();
                    if (usr != null)
                        return JsonConvert.SerializeObject(_usrModelMapper.MapNew(usr));
                    throw new Exception(USUARIO_NO_EXISTE);
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(int id)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    var usr = db.Usuario?.Where(x => x.id == id)?.FirstOrDefault();
                    if (usr != null)
                        db.Usuario.Remove(usr);
                    throw new Exception("El usuario no existe");
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetSesiones(int id)
        {
            using (var db = new seguridadEntities())
            {
                SesionService sesionService = new SesionService();
                return sesionService.GetAll(id);
            }
        }
    }
}
