using System;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad:"Bogota", pais:"Colombia");
            var arregloCursos = new Curso[3];
            arregloCursos[0] = new Curso() {Nombre="101"};
            arregloCursos[1] = new Curso() {Nombre="201"};
            arregloCursos[2] = new Curso() {Nombre="301"};
            Console.WriteLine(escuela);
            System.Console.WriteLine("============");
            ImprimirCursos(arregloCursos);
        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int cont=0;
            while (cont < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[cont].Nombre}, ID: {arregloCursos[cont].UniqueID}");
                cont++;
            }
        }
    }
}
