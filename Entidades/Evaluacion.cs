using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        public Evaluacion(string nombre, Alumno alumno, Asignatura asignatura, float nota)
        {
            UniqueID = Guid.NewGuid().ToString();
            Nombre = nombre;
            Alumno = alumno;
            Asignatura = asignatura;
            Nota = nota;
        }
        public Evaluacion() => UniqueID = Guid.NewGuid().ToString();
    }
}