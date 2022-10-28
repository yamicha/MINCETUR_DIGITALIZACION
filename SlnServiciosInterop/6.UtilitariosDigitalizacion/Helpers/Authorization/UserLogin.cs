using System;
using System.Collections.Generic;
using System.Text;

namespace Utilitarios.Helpers.Authorization
{
    public class UserLogin
    {
        public UserLogin() {
            Usuario_Valido = true; 
        }
        public string Codusuario { get; set; }
        public int IdOficina { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string DesOficina { get; set; }
        public string DesPerfil { get; set; }
        public string NameApellidos { get; set; }
        public bool Usuario_Valido { get; set; }
        public string token { get; set; }
        public string Modulos { get; set; }
    }
}
