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
        private string urlload = "https://kid1988421.000webhostapp.com/load.php";
        private WWWForm form;
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();                               // �s�W ��檫��
            form.AddField("coin", goldManager.goldCount);       // ���K�[�������P��
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            StartCoroutine(StartLinkData(urlSave));                    // �Ұ��x�s���
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("search", "coin");
            StartCoroutine(StartLoadData("����"));

            form = new WWWForm();
            form.AddField("search", "posX");
            StartCoroutine(StartLoadData("�y�� X"));

            form = new WWWForm();
            form.AddField("search", "posY");
            StartCoroutine(StartLoadData("�y�� Y"));
        }

        private IEnumerator StartLoadData(string update)
        {
            yield return StartCoroutine(StartLinkData(urlload));

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
        }

        private IEnumerator StartLinkData(string url)
        {
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))   // �z�L�����ǿ�ǻ���ƨ� save.php
            {
                yield return www.SendWebRequest();                              // ���ݶǿ�
                result = www.downloadHandler.text;
                print(result);
            }
        }
    }
}
