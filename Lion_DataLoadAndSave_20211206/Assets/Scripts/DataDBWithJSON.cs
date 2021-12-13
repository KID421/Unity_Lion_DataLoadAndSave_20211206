using UnityEngine;

namespace KID
{
    /// <summary>
    /// 透過資料庫存取資料
    /// 資料使用 JSON 存取
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        public override void SaveData()
        {
            base.SaveData();

            // 新增玩家資料並儲存金幣、座標 X、座標 Y
            PlayerData data = new PlayerData(goldManager.goldCount, player.position.x, player.position.y);
            // JSON 字串 = JSON 單位.轉 JSON (玩家資料)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON 資料：<color=yellow>" + dataJSON + "</color>");
        }

        public override void LoadData()
        {
            base.LoadData();
        }
    }
}
