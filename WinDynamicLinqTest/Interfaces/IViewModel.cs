namespace WinDynamicLinqTest.Interfaces
{
    /// <summary>
    /// ViewModelインターフェース
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Modelインスタンスの設定
        /// </summary>
        /// <param name="model">設定するModelインスタンス</param>
        void SetModel(IModel model);

        /// <summary>
        /// Modelインスタンスの取得
        /// </summary>
        /// <returns>IModelインスタンス</returns>
        IModel GetModel();
    }
}
