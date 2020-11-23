using System;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase generica que implementa la interfaz IExportador. Exporta los datos a un archivo XML
    /// </summary>
    public class Exportador<T> : IExportador<T>
    {
        #region METODOS
        /// <summary>
        /// Exporta los datos pasados como parametro al archivo XML
        /// </summary>
        /// <param name="archivo"> Archivo donde se guardara el XML </param>
        /// <param name="datos"> Datos a guardar </param>
        /// <returns></returns>
        public void Exportar(string archivo, T datos)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamWriter f = new StreamWriter(archivo);
                s.Serialize(f, datos);
                f.Close();
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al intentar exportar los datos de " + typeof(T).Name + ": " + ex.Message);
            }
        }
        #endregion
    }
}
