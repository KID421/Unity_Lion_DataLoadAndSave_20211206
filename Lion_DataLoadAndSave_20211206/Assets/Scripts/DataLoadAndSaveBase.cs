using UnityEngine;

namespace KID
{
    /// <summary>
    /// 資料存取基底
    /// 載入資料
    /// 儲存資料
    /// </summary>
    public class DataLoadAndSaveBase : MonoBehaviour
    {
        [Header("要儲存的資料")]
        public GoldManager goldManager;
        public Transform player;

        #region 方法：公開並允許複寫
        /// <summary>
        /// 儲存資料
        /// </summary>
        public virtual void SaveData()
        {

        }

        /// <summary>
        /// 載入資料
        /// </summary>
        public virtual void LoadData()
        {

        }
        #endregion
    }
}
