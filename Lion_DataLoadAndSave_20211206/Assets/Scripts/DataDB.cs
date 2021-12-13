using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

namespace KID
{
    /// <summary>
    /// �ϥθ�Ʈw�s�����
    /// </summary>
    public class DataDB : DataLoadAndSaveBase
    {
        private string urlSave = "https://kid1988421.000webhostapp.com/save.php";
        private string urlLoad = "https://kid1988421.000webhostapp.com/load.php";
        private WWWForm form;
        /// <summary>
        /// �ǿ鵲�G
        /// </summary>
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();                               // �s�W ��檫��
            form.AddField("coin", goldManager.goldCount);       // ���K�[�������P��
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            StartCoroutine(StartLinkData(urlSave));             // �Ұ��x�s���
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("search", "coin");
            StartCoroutine(StartLinkData(urlLoad, "����"));

            form = new WWWForm();
            form.AddField("search", "posX");
            StartCoroutine(StartLinkData(urlLoad, "�y�� X"));

            form = new WWWForm();
            form.AddField("search", "posY");
            StartCoroutine(StartLinkData(urlLoad, "�y�� Y"));
        }

        private IEnumerator StartLinkData(string url, string updateItem = "")
        {
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))       // �z�L�����ǿ�ǻ���ƨ� save.php
            {
                yield return www.SendWebRequest();                              // ���ݶǿ�
                print("�ǿ骬�A�G" + www.isDone);
                result = www.downloadHandler.text;                              // �ǿ鵲�G
                print("�ǿ鵲�G�G" + result);
            }

            if (updateItem == "����")
            {
                goldManager.goldCount = Convert.ToInt32(result);
                goldManager.UpdateData();
            }
            else if (updateItem == "�y�� X")
            {
                float x = Convert.ToSingle(result);
                player.position = new Vector3(x, player.position.y, 0);
            }
            else if (updateItem == "�y�� Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }
        }
    }
}
