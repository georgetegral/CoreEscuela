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
            //Eliminar todos los elementos de la colección
            //otrColeccion.Clear();
            //Curso tmp = new Curso{Nombre = "101-Vacacional", Jornada = TiposJornada.Noche};
            escuela.Cursos.AddRange(otrColeccion);
            //escuela.Cursos.Add(tmp);

            WriteLine(escuela);
            ImprimirCursosEscuela(escuela);
            //Obtener el identificador del curso
            //WriteLine("Curso.Hash"+ tmp.GetHashCode());
            //Eliminar un curso en especifico
            //escuela.Cursos.Remove(tmp);
            //Esto es un delegado para asegurar que el predicado regresa un tipo de dato correcto
            Predicate<Curso>miAlgoritmo = Predicado;
            escuela.Cursos.RemoveAll(miAlgoritmo);
            ImprimirCursosEscuela(escuela);
        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre == "301";
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
