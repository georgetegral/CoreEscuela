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
            /*
            //Printer.Beep(10000, cantidad:2);
            ImprimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos,
                traeEvaluaciones:false
            );
            var dicTmp = engine.getDiccionarioObjetos();
            engine.ImprimirDiccionario(dicTmp);
            */
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
