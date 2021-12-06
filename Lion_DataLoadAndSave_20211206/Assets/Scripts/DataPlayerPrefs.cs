using UnityEngine;

namespace KID
{
    /// <summary>
    /// ��Ʀs��
    /// PP �Ҧ��G�ϥ� Unity API Player Prefs
    /// </summary>
    public class DataPlayerPrefs : DataLoadAndSaveBase
    {
        [Header("PP �M���x�s��� KEY")]
        public string keyGold = "�����ƶq";
        public string keyX = "���aX�b";
        public string keyY = "���aY�b";

        public override void SaveData()
        {
            base.SaveData();

            #region �x�s���
            PlayerPrefs.SetInt(keyGold, goldManager.goldCount);
            PlayerPrefs.SetFloat(keyX, player.position.x);
            PlayerPrefs.SetFloat(keyY, player.position.y);
            #endregion
        }

        public override void LoadData()
        {
            base.LoadData();

            #region Ū�����
            goldManager.goldCount = PlayerPrefs.GetInt(keyGold);
            Vector3 positionLoad = Vector3.zero;
            positionLoad.x = PlayerPrefs.GetFloat(keyX);
            positionLoad.y = PlayerPrefs.GetFloat(keyY);
            #endregion

            #region ��s����
            goldManager.UpdateData();
            player.position = positionLoad;
            #endregion
        }
    }
}
