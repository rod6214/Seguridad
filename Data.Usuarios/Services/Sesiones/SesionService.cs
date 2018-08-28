using Data.Usuarios.Entities;
using Data.Usuarios.Mappers;
using Model.Usuarios.Sesiones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Usuarios.Services.Sesiones
{
    public class SesionService
    {
        private UsuarioModelMapper _usrModelMapper = new UsuarioModelMapper();
        private UsuarioMapper _usrMapper = new UsuarioMapper();
        private SesionModelMapper _sesModelMapper = new SesionModelMapper();
        private SesionMapper _sesMapper = new SesionMapper();

        public string GetAll()
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    List<SesionModel> sesions = new List<SesionModel>();
                    foreach (var sesion in db.Sesion)
                        sesions.Add(_sesModelMapper.MapNew(sesion));
                    return JsonConvert.SerializeObject(sesions, Formatting.Indented);
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetAll(int usuarioId)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    List<SesionModel> sesions = new List<SesionModel>();
                    var userSesions = db.Sesion?.Where(x => x.Usuario_id == usuarioId);
                    if (userSesions == null)
                        throw new Exception("El usuario no existe");
                    foreach (var sesion in userSesions)
                        sesions.Add(_sesModelMapper.MapNew(sesion));
                    return JsonConvert.SerializeObject(sesions, Formatting.Indented);
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Create(string usuariojson)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    SesionModel usrModel = JsonConvert.DeserializeObject<SesionModel>(usuariojson);
                    Sesion usr = _sesMapper.MapNew(usrModel);
                    db.Sesion.Add(usr);
                    db.SaveChanges();
                    return string.Empty;
                }
            }
            catch (Exception ex)
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
                    SesionModel sesModel = JsonConvert.DeserializeObject<SesionModel>(usuariojson);
                    var sesion = db.Sesion?.Where(x => x.id == sesModel.Id)?.FirstOrDefault();
                    if (sesion != null)
                    {
                        sesModel.Id = sesion.id;
                        _sesMapper.Map(sesModel, sesion);
                        db.SaveChanges();
                        return string.Empty;
                    }
                    else
                        throw new Exception("El usuario no existe");
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
                    var sesion = db.Sesion?.Where(x => x.id == id)?.FirstOrDefault();
                    if (sesion != null)
                        return JsonConvert.SerializeObject(_sesModelMapper.MapNew(sesion));
                    throw new Exception("El usuario no existe");
                }
            }
            catch (Exception ex)
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
                    var sesion = db.Sesion?.Where(x => x.id == id)?.FirstOrDefault();
                    if (sesion != null)
                        db.Sesion.Remove(sesion);
                    throw new Exception("El usuario no existe");
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetUsuario(int id)
        {
            try
            {
                using (var db = new seguridadEntities())
                {
                    var sesion = db.Sesion?.Where(x => x.id == id)?.FirstOrDefault();
                    if(sesion != null)
                    {
                        SesionModel sesionModel = _sesModelMapper.MapNew(sesion);
                        var usuario = db.Usuario?.Where(x => x.id == sesionModel.UsuarioId)?.FirstOrDefault();
                        if(usuario != null)
                            return JsonConvert.SerializeObject(usuario);
                        throw new Exception("El usuario no existe");
                    }
                    throw new Exception("La sesion no existe");
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
