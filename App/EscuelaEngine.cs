using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            CargarCursos();
            foreach (var curso in Escuela.Cursos)
            {
                curso.Alumnos.AddRange(CargarAlumnos());
            }

            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{ Nombre = "Matemáticas" },
                    new Asignatura{ Nombre = "Educación Física" },
                    new Asignatura{ Nombre = "Español" },
                    new Asignatura{ Nombre = "Ciencias Naturales" }
                };
                curso.Asignaturas.AddRange(listaAsignaturas);
            }
        }

        private IEnumerable<Alumno> CargarAlumnos()
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
            return listaAlumnos;
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
        }
    }
}