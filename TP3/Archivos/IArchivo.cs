namespace Archivos
{
    public interface IArchivo<T>
    {
        #region METODOS
        /// <summary>
        /// Guarda en un archivo
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Datos </param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee de un archivo
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Datos </param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
        #endregion
    }
}
