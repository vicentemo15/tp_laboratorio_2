using System;
using System.IO;

namespace Entidades
{
    /// <summary>
    /// Clase estatica para guardar y leer en el archivo logs.txt (se guarda en el escritorio)
    /// </summary>
    public static class Logger
    {
        #region ATRIBUTOS
        private static object objLock = new Object();
        #endregion

        #region METODOS
        /// <summary>
        /// Inicializa el archivo de logs al iniciar la aplicacion
        /// </summary>
        /// <returns></returns>
        public static void CrearArchivo()
        {
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\logs.txt";
            FileStream file = File.Create(archivo);
            file.Close();
        }

        /// <summary>
        /// Metodo que guarda en el archivo los datos.
        /// El lock es generado para manejar el acceso al archivo por los diferentes hilos
        /// </summary>
        /// <param name="datos"> String a guardar en el archivo </param>
        /// <returns></returns>
        public static void Guardar(string datos)
        {
            lock(objLock)
            {
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\logs.txt";

                try
                {
                    StreamWriter f = new StreamWriter(archivo, true);
                    f.Write(DateTime.Now + " - " + datos + "\n");
                    f.Close();
                }
                catch (Exception e)
                {
                    throw new ErrorArchivoException("Error al intentar guardar en el archivo de logs. Mensaje: " + e.Message);
                }
            }
        }

        /// <summary>
        /// Metodo que lee los datos de logs.
        /// </summary>
        /// <returns>Cadena de datos leida del archivo</returns>
        public static string Leer()
        {
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\logs.txt";

            try
            {
                StreamReader f = new StreamReader(archivo);
                string datos = f.ReadToEnd();
                f.Close();
                return datos;
            }
            catch (Exception e)
            {
                throw new ErrorArchivoException("Error al intentar leer del archivo de logs. Mensaje: " + e.Message);
            }
        }
        #endregion
    }
}
