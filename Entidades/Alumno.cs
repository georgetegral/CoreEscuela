using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
        public Alumno() => UniqueID = Guid.NewGuid().ToString();
    }
}