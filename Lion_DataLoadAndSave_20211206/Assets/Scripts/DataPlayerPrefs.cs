using UnityEngine;

namespace KID
{
    /// <summary>
    /// 資料存取
    /// PP 模式：使用 Unity API Player Prefs
    /// </summary>
    public class DataPlayerPrefs : DataLoadAndSaveBase
    {
        [Header("PP 專用儲存資料 KEY")]
        public string keyGold = "金幣數量";
        public string keyX = "玩家X軸";
        public string keyY = "玩家Y軸";

        public override void SaveData()
        {
            base.SaveData();

            #region 儲存資料
            PlayerPrefs.SetInt(keyGold, goldManager.goldCount);
            PlayerPrefs.SetFloat(keyX, player.position.x);
            PlayerPrefs.SetFloat(keyY, player.position.y);
            #endregion
        }

        public override void LoadData()
        {
            base.LoadData();

            #region 讀取資料
            goldManager.goldCount = PlayerPrefs.GetInt(keyGold);
            Vector3 positionLoad = Vector3.zero;
            positionLoad.x = PlayerPrefs.GetFloat(keyX);
            positionLoad.y = PlayerPrefs.GetFloat(keyY);
            #endregion

            #region 更新物件
            goldManager.UpdateData();
            player.position = positionLoad;
            #endregion
        }
    }
}
