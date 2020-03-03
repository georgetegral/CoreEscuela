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
        private float ObtenerNotaAleatoria(){
            Random rnd = new Random();
            float nota = (float) (5* rnd.NextDouble());
            return nota;
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
        public Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> getDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] {Escuela});
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos);
            return diccionario;
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true, 
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true, 
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true, 
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true, 
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true, 
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if(traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if(traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);
                if(traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);
                if(traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return listaObj.AsReadOnly();
        }
        #region Métodos de carga
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
    #endregion
}