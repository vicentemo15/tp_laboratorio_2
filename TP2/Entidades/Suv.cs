using System;
using System.Text;

namespace Entidades
{  /// <summary>
   /// La clase Suv heredada de la clase Vehiculo.
   /// </summary>
    public class Suv : Vehiculo
    {
        #region "Constructores"
        /// <summary>
        /// Construcctor de la clase
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="chasis">Chasis</param>
        /// <param name="color">Color</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region "Metodos"

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Cadena con datos del vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}