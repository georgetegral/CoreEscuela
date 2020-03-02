namespace CoreEscuela.Entidades
{
    class Escuela
    {
        public string Nombre {get;set;}
        public int AñoDeCreacion{get;set;}
        public string Pais {get;set;}
        public string Ciudad {get;set;}
        public TiposEscuela TipoEscuela{get;set;}
        //Forma 1 de declararlo
        /*
        public Escuela(string nombre, int año)
        {
            Nombre = nombre;
            AñoDeCreacion = año;
        }
        */
        //Forma 2 de declararlo
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);
        
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \n Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}