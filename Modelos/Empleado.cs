using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Administracion_Hotel.Modelos
{
    public class Empleado : Persona
    {
        // Propiedades exclusivas del Empleado
        public int IdRol { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public Empleado() { }

        public Empleado(int id, string nombre, string apellidos, int idRol, string usuario, string contrasena)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.IdRol = idRol;
            this.Usuario = usuario;
            this.Contrasena = contrasena;
        }
    }
}
