namespace WinDynamicLinqTest.Interfaces
{
    /// <summary>
    /// ViewModelインターフェース
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Modelインスタンスの取得
        /// </summary>
        /// <returns>IModelインスタンス</returns>
        IModel GetModel();
    }
}
