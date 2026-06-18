using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Administracion_Hotel.Modelos
{
    public abstract class Persona
    {
        // Propiedades compartidas
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        // Un método útil que ambos heredarán automáticamente
        public string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
}
