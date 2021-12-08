using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using UnityEngine.TestTools;

namespace KID
{
    /// <summary>
    /// 使用 GAS 存取資料
    /// Google Application Script
    /// </summary>
    public class DataGAS : DataLoadAndSaveBase
    {
        /// <summary>
        /// GAS 連結
        /// </summary>
        private string gas = "https://script.google.com/macros/s/AKfycbzL0BuL9c5KlubbuZbOoVPCKvV9oPGE4jzxVae339wBeFYdg2IrUn1kNf5vORoMymlJ/exec";
        private WWWForm form;
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            #region 儲存資料
            form = new WWWForm();
            form.AddField("coin", goldManager.goldCount);
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            #endregion

            StartCoroutine(LinkGAS("寫入"));
        }

        public override void LoadData()
        {
            base.LoadData();

            #region 讀取資料
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 1);
            StartCoroutine(LoadGASData("金幣"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("座標 X"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("座標 Y"));
            #endregion
        }

        private IEnumerator LoadGASData(string update)
        {
            yield return StartCoroutine(LinkGAS("讀取"));

            #region 更新物件
            if (update == "金幣")
            {
                goldManager.goldCount = Convert.ToInt32(result);
                goldManager.UpdateData();
            }
            else if (update == "座標 X")
            {
                float x = Convert.ToSingle(result);
                player.position = new Vector3(x, player.position.y, 0);
            }
            else if (update == "座標 Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }
            #endregion
        }

        /// <summary>
        /// 連結到 GAS
        /// </summary>
        /// <param name="loadOrSave">寫入、讀取</param>
        private IEnumerator LinkGAS(string loadOrSave)
        {
            form.AddField("method", loadOrSave);

            using (UnityWebRequest www = UnityWebRequest.Post(gas, form))
            {
                yield return www.SendWebRequest();

                result = www.downloadHandler.text;

                print(result);
            }
        }
    }
}
