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
            //escuela.Pais = "Colombia";
            //escuela.Ciudad = "Bogotá";
            //escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);
        }
    }
}
