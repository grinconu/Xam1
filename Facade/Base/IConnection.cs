namespace Facade.Base
{
    /// <summary>
    /// Connection Services o SqlLite.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Online this instance.
        /// </summary>
        /// <returns>The online.</returns>
        bool ConectadoRed();

        /// <summary>
        /// Respondes the servicio.
        /// </summary>
        /// <returns><c>true</c>, if servicio was responded, <c>false</c> otherwise.</returns>
        /// <param name="Uri">URI.</param>
        bool RespondeServicio(string Uri);

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>The file path.</returns>
        /// <param name="dbName">Db name.</param>
        string GetFilePath(string dbName);
    }
}
