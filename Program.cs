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
            var curso1 = new Curso() {Nombre="101"};
            var curso2 = new Curso() {Nombre="201"};
            var curso3 = new Curso() {Nombre="301"};
            //var arregloCursos = new Curso[3];
            Console.WriteLine(escuela);
            System.Console.WriteLine("============");

            System.Console.WriteLine(curso1.Nombre+", "+curso1.UniqueID);
            System.Console.WriteLine($"{curso2.Nombre}, {curso1.UniqueID}");
            System.Console.WriteLine(curso3.Nombre+", "+curso3.UniqueID);
        }
    }
}
