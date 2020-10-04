using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Cliclomotor heredada de la clase Vehiculo.
    /// </summary>
    public class Ciclomotor : Vehiculo
    {
        #region    "Constructores"
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        ///  /// <param name="marca">Marca</param>
        /// <param name="chasis">Chasis</param>
        /// <param name="color">Color</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base (chasis,marca,color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region "Metodos"    
        /// <summary>
        /// Publica todos los datos del Ciclomotor.
        /// </summary>
        /// <returns>Cadena con los datos del vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
