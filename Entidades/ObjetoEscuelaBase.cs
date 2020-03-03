using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueID { get; private set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
        public override string ToString()
        {
            return $"{Nombre}, {UniqueID}";
        }
    }
}