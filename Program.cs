using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se ejecutan en orden cuando el proceso termina
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o,s) => Printer.Beep(2000,1000,1);
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento; //Se elimina este

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("¡Bienvenido a la escuela!");
            //var reporteador = new Reporteador(engine.getDiccionarioObjetos());
            var reporteador = new Reporteador(null);
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsig = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluaXAsig();
            var listaPromXAsig = reporteador.GetPromAlumPorAsignatura();
            
            Printer.WriteTitle("Captura de una evaluación por consola");

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PressEnter();
            string nombre = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                nombre = nombre.ToLower();
                WriteLine("Nombre ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PressEnter();
            string notaStr = Console.ReadLine();
            float nota;

            try
            {
                nota = float.Parse(notaStr);
                if (nota < 0 || nota > 5)
                {
                    throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                }
                WriteLine("La nota de la evaluacion ha sido ingresada correctamente");
                return;
            }
            catch (ArgumentOutOfRangeException argE)
            {
                Printer.WriteTitle(argE.Message);
                WriteLine("Saliendo del programa");
            }
            finally
            {
                Printer.WriteTitle("FINALLY");
                Printer.Beep(2500, 500, 3);

            }
            

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo");
            Printer.Beep(3000,1000,3);
            Printer.WriteTitle("¡Salió!");
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
