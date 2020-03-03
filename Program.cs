using System;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");
            var arregloCursos = new Curso[3];
            arregloCursos[0] = new Curso() { Nombre = "101" };
            arregloCursos[1] = new Curso() { Nombre = "201" };
            arregloCursos[2] = new Curso() { Nombre = "301" };
            Console.WriteLine(escuela);
            System.Console.WriteLine("=====================");
            ImprimirCursosForEach(arregloCursos);
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int cont = 0;
            while (cont < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[cont].Nombre}, ID: {arregloCursos[cont].UniqueID}");
                cont++;
            }
        }
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int cont = 0;
            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[cont].Nombre}, ID: {arregloCursos[cont].UniqueID}");
                cont++;
            } while (cont < arregloCursos.Length);
        }
        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre: {arregloCursos[i].Nombre}, ID: {arregloCursos[i].UniqueID}");
            }
        }
        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, ID: {curso.UniqueID}");
            }
        }
    }
}
