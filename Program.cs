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
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario[0]="Peckerman";
            diccionario.Add(10,"Juan");
            diccionario.Add(23,"Lorem Ipsum");
            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }
            Printer.WriteTitle("Acceso a diccionario");
            WriteLine(diccionario[23]);
            Printer.WriteTitle("Otro diccionario");
            var dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo celeste que gira alrededor de la tierra.";
            WriteLine(dic["Luna"]);
            dic["Luna"] = "Protagonista de Soy Luna.";
            WriteLine(dic["Luna"]);
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
