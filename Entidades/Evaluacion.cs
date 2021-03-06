using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion: ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        public Evaluacion(string nombre, Alumno alumno, Asignatura asignatura, float nota)
        {
            Nombre = nombre;
            Alumno = alumno;
            Asignatura = asignatura;
            Nota = nota;
        }
        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}