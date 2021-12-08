using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace KID
{
    /// <summary>
    /// �ϥθ�Ʈw�s�����
    /// </summary>
    public class DataDB : DataLoadAndSaveBase
    {
        private string urlSave = "https://kid1988421.000webhostapp.com/save.php";
        private WWWForm form;

        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();                               // �s�W ��檫��
            form.AddField("coin", goldManager.goldCount);       // ���K�[�������P��
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            StartCoroutine(StartSaveData());                    // �Ұ��x�s���
        }

        public override void LoadData()
        {
            base.LoadData();
        }

        private IEnumerator StartSaveData()
        {
            using (UnityWebRequest www = UnityWebRequest.Post(urlSave, form))   // �z�L�����ǿ�ǻ���ƨ� save.php
            {
                yield return www.SendWebRequest();                              // ���ݶǿ�
                print("�ǿ骬�A�G" + www.isDone);
            }
        }
    }
}
