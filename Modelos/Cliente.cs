using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Administracion_Hotel.Modelos
{
    // Los dos puntos (:) indican que Cliente hereda de Persona
    public class Cliente : Persona
    {
        // Propiedades exclusivas del Cliente
        public string Telefono { get; set; }
        public string Correo { get; set; }

        // Constructor vacío (necesario para instanciar rápido)
        public Cliente() { }

        // Constructor con parámetros para facilitar la creación
        public Cliente(int id, string nombre, string apellidos, string telefono, string correo)
        {
            this.Id = id; // Viene de Persona
            this.Nombre = nombre; // Viene de Persona
            this.Apellidos = apellidos; // Viene de Persona
            this.Telefono = telefono;
            this.Correo = correo;
        }
    }
}
