using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region METODOS
        /// <summary>
        /// Guarda una cadena de texto en un archivo
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Datos </param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter f = new StreamWriter(archivo);
                f.Write(datos);
                f.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Devuelve el contenido del archivo
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Salida del archivo</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader f = new StreamReader(archivo);
                datos = f.ReadToEnd();
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
