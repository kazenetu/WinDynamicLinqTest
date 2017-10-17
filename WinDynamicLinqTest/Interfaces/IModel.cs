using System;

namespace WinDynamicLinqTest.Interfaces
{
    /// <summary>
    /// モデルインスタンス
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// ModelのTypeを返す
        /// </summary>
        /// <returns>ModelのType</returns>
        Type GetModelType();
    }
}
