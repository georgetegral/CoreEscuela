using System;
using System.Collections.Generic;
using System.Linq;
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
            var listaObjetos = engine.GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos,
                traeEvaluaciones:false
            );
            var dicTmp = engine.getDiccionarioObjetos();
            engine.ImprimirDiccionario(dicTmp);
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
