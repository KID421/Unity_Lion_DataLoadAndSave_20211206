using UnityEngine;

namespace KID
{
    /// <summary>
    /// �z�L��Ʈw�s�����
    /// ��ƨϥ� JSON �s��
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        public override void SaveData()
        {
            base.SaveData();

            // �s�W���a��ƨ��x�s�����B�y�� X�B�y�� Y
            PlayerData data = new PlayerData(goldManager.goldCount, player.position.x, player.position.y);
            // JSON �r�� = JSON ���.�� JSON (���a���)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON ��ơG<color=yellow>" + dataJSON + "</color>");
        }

        public override void LoadData()
        {
            base.LoadData();
        }
    }
}
