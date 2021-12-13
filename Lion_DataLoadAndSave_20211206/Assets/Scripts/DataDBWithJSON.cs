using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace KID
{
    /// <summary>
    /// 透過資料庫存取資料
    /// 資料使用 JSON 存取
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        private string urlSave = "https://kid1988421.000webhostapp.com/savejson.php";
        private string urlLoad = "https://kid1988421.000webhostapp.com/loadjson.php";

        private WWWForm form;
        private string result;

        public override void SaveData()
        {
            base.SaveData();
            // 新增玩家資料並儲存金幣、座標 X、座標 Y
            PlayerData data = new PlayerData(goldManager.goldCount, player.position.x, player.position.y, player.rotation, Time.timeSinceLevelLoad);
            // JSON 字串 = JSON 單位.轉 JSON (玩家資料)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON 資料：<color=yellow>" + dataJSON + "</color>");

            // 將 JSON 資料 添加到 表單內 欄位名稱為［json］
            form = new WWWForm();
            form.AddField("json", dataJSON);
            StartCoroutine(StartLinkData(urlSave));
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("json", "json");
            StartCoroutine(StartLinkData(urlLoad, true));
        }

        /// <summary>
        /// 開始連結資料庫
        /// </summary>
        /// <param name="url">要溝通的 PHP 連結</param>
        /// <param name="load">是否為載入模式</param>
        private IEnumerator StartLinkData(string url, bool load = false)
        {
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();
                print("傳輸狀態：" + www.isDone);
                result = www.downloadHandler.text;
                print("傳輸結果：" + result);
            }

            if (load)
            {
                // 將 JSON 轉為玩家資料
                // Json 單位.從 JSON 轉資料<型別>(JSON)
                PlayerData data = JsonUtility.FromJson<PlayerData>(result);
                print("取得的金幣：<color=yellow>" + data.coin + "</color>");
                
                goldManager.goldCount = data.coin;
                goldManager.UpdateData();

                float x = data.posX;
                float y = data.posY;
                player.position = new Vector3(x, y, 0);
                player.rotation = data.angle;

                print("上次遊玩時間：<color=green>" + data.time + "</color>");
            }
        }
    }
}
