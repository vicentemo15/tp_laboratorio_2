using Excepciones;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region METODOS
        /// <summary>
        /// Guarda un XML con los datos del objeto
        /// </summary>
        /// <param name="archivo"> Parth del archivo</param>
        /// <param name="datos"> Datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamWriter f = new StreamWriter(archivo);
                s.Serialize(f, datos);
                f.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee archivo serializado .xml y retorna el objeto.
        /// </summary>
        /// <param name="archivo"> Path del archivo </param>
        /// <param name="datos"> Datos leidos </param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamReader f = new StreamReader(archivo);
                datos = (T)s.Deserialize(f);
                f.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion
    }
}