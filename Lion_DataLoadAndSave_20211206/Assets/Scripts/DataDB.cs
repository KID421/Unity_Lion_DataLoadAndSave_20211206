using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

namespace KID
{
    /// <summary>
    /// 使用資料庫存取資料
    /// </summary>
    public class DataDB : DataLoadAndSaveBase
    {
        private string urlSave = "https://kid1988421.000webhostapp.com/save.php";
        private string urlLoad = "https://kid1988421.000webhostapp.com/load.php";
        private WWWForm form;
        /// <summary>
        /// 傳輸結果
        /// </summary>
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();                               // 新增 表單物件
            form.AddField("coin", goldManager.goldCount);       // 表單添加金幣欄位與值
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            StartCoroutine(StartLinkData(urlSave));             // 啟動儲存資料
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("search", "coin");
            StartCoroutine(StartLinkData(urlLoad, "金幣"));

            form = new WWWForm();
            form.AddField("search", "posX");
            StartCoroutine(StartLinkData(urlLoad, "座標 X"));

            form = new WWWForm();
            form.AddField("search", "posY");
            StartCoroutine(StartLinkData(urlLoad, "座標 Y"));
        }

        private IEnumerator StartLinkData(string url, string updateItem = "")
        {
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))       // 透過網路傳輸傳遞資料到 save.php
            {
                yield return www.SendWebRequest();                              // 等待傳輸
                print("傳輸狀態：" + www.isDone);
                result = www.downloadHandler.text;                              // 傳輸結果
                print("傳輸結果：" + result);
            }

            if (updateItem == "金幣")
            {
                goldManager.goldCount = Convert.ToInt32(result);
                goldManager.UpdateData();
            }
            else if (updateItem == "座標 X")
            {
                float x = Convert.ToSingle(result);
                player.position = new Vector3(x, player.position.y, 0);
            }
            else if (updateItem == "座標 Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }
        }
    }
}
