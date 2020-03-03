namespace CoreEscuela.Entidades
{
    class Escuela
    {
        public string Nombre { get; set; }
        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);
        //Inicializar los elementos significa que son opcionales
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            Nombre = nombre;
            AñoDeCreacion = año;
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela}{System.Environment.NewLine}Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}