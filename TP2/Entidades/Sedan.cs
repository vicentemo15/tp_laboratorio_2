using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Sedan  heredada de la clase Vehiculo.
    /// </summary>
    public class Sedan : Vehiculo
    {
        #region "Enumerados"
        public enum ETipo 
        {
          CuatroPuertas, CincoPuertas 
        }
        #endregion

        #region "Atributos"
        private ETipo tipo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="chasis">Chasis</param>
        /// <param name="color">Color</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="chasis">Chasis</param>
        /// <param name="color">Color</param>
        /// <param name="tipo">Tipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo): this (marca, chasis,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades" 
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Sedan.
        /// </summary>
        /// <returns>Cadena con datos del vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); 
        }
        #endregion
    }
}