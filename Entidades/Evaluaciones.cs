using System;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        public Evaluaciones(string nombre, Alumno alumno, Asignatura asignatura, float nota)
        {
            UniqueID = Guid.NewGuid().ToString();
            Nombre = nombre;
            Alumno = alumno;
            Asignatura = asignatura;
            Nota = nota;
        }
        public Evaluaciones() => UniqueID = Guid.NewGuid().ToString();
    }
}