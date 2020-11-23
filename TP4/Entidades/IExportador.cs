namespace Entidades
{
    /// <summary>
    /// Interfaz para clases exportadoras
    /// </summary>
    public interface IExportador<T>
    {
        void Exportar(string archivo, T datos);
    }
}
