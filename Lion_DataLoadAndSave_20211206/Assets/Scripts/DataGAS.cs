using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using UnityEngine.TestTools;

namespace KID
{
    /// <summary>
    /// �ϥ� GAS �s�����
    /// Google Application Script
    /// </summary>
    public class DataGAS : DataLoadAndSaveBase
    {
        /// <summary>
        /// GAS �s��
        /// </summary>
        private string gas = "https://script.google.com/macros/s/AKfycbzL0BuL9c5KlubbuZbOoVPCKvV9oPGE4jzxVae339wBeFYdg2IrUn1kNf5vORoMymlJ/exec";
        private WWWForm form;
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            #region �x�s���
            form = new WWWForm();
            form.AddField("coin", goldManager.goldCount);
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            #endregion

            StartCoroutine(LinkGAS("�g�J"));
        }

        public override void LoadData()
        {
            base.LoadData();

            #region Ū�����
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 1);
            StartCoroutine(LoadGASData("����"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("�y�� X"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("�y�� Y"));
            #endregion
        }

        private IEnumerator LoadGASData(string update)
        {
            yield return StartCoroutine(LinkGAS("Ū��"));

            #region ��s����
            if (update == "����")
            {
                goldManager.goldCount = Convert.ToInt32(result);
                goldManager.UpdateData();
            }
            else if (update == "�y�� X")
            {
                float x = Convert.ToSingle(result);
                player.position = new Vector3(x, player.position.y, 0);
            }
            else if (update == "�y�� Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }
            #endregion
        }

        /// <summary>
        /// �s���� GAS
        /// </summary>
        /// <param name="loadOrSave">�g�J�BŪ��</param>
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
