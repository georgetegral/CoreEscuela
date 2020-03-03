using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "301", Jornada = TiposJornada.Mañana }
            };
            escuela.Cursos.Add(new Curso() { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso() { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otrColeccion = new List<Curso>(){
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "502", Jornada = TiposJornada.Tarde }
            };
            WriteLine(escuela);
            escuela.Cursos.AddRange(otrColeccion);
            ImprimirCursosEscuela(escuela);
            //Forma 1
            /*
            escuela.Cursos.RemoveAll(delegate (Curso cur)
            {
                return cur.Nombre == "301";
            });
            */
            //Forma 2 con expresiones Lambda
            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "301" && cur.Jornada == TiposJornada.Mañana);
            ImprimirCursosEscuela(escuela);
        }
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("========================");
            WriteLine("Cursos de la escuela");
            WriteLine("========================");
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    Console.WriteLine($"Nombre: {curso.Nombre}, ID: {curso.UniqueID}");
                }
            }
        }
    }
}
