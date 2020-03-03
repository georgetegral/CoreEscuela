using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluacionesAlAzar();
        }

        private void CargarEvaluacionesAlAzar()
        {
            string[] evaluaciones = { "Tarea 1", "Tarea 2", "Tarea 3", "Proyecto parcial", "Examen parcial" };
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < evaluaciones.Length; i++)
                        {
                            var evaluacion = new Evaluacion(evaluaciones[i],alumno,asignatura,ObtenerNotaAleatoria());
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }

        private float ObtenerNotaAleatoria(){
            Random rnd = new Random();
            float nota = (float) (5* rnd.NextDouble());
            return nota;
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                curso.Asignaturas = new List<Asignatura>()
                {
                    new Asignatura{ Nombre = "Matemáticas" },
                    new Asignatura{ Nombre = "Educación Física" },
                    new Asignatura{ Nombre = "Español" },
                    new Asignatura{ Nombre = "Ciencias Naturales" }
                };
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Jorge", "Gabriel", "Juan", "Federico", "Elsa", "Patricia", "Daniela" };
            string[] nombre2 = { "René", "Aldahir", "Lopez", "María", "Patricio" };
            string[] apellido1 = { "García", "López", "Jiménez", "Rosado", "Uribe", "Garza" };
            string[] apellido2 = { "Rosado", "Soto", "Reséndiz", "Santana", "Doriga" };
            //Usando Linq
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               from a2 in apellido2
                               select new Alumno { Nombre = $"{n1} {n2} {a1} {a2}" };
            return listaAlumnos.OrderBy((alumno) => alumno.UniqueID).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "301", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana }
            };
            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5,20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }

        }
    }
}