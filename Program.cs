using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("¡Bienvenido a la escuela!");
            //Printer.Beep(10000, cantidad:2);
            ImprimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela();
            /*
            Printer.WriteTitle("Pruebas de polimorfismo");
            var alumnoTest = new Alumno{Nombre = "Claire Underwood"};
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Alumno: {ob.GetType()}");
            */
        }
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la escuela");
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
