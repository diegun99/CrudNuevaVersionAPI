﻿namespace CrudNuevaVersionAPI.Entities
{
    public class Empleado
    {
        // con prop snippet  para generar propiedades
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }

        public int Sueldo { get; set; }
        public int IdPerfil { get; set; }

        public virtual Perfil PerfilReferencia { get; set; }
    }
}
