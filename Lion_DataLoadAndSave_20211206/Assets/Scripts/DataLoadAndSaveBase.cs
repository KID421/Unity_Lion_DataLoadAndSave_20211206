using UnityEngine;

namespace KID
{
    /// <summary>
    /// ��Ʀs����
    /// ���J���
    /// �x�s���
    /// </summary>
    public class DataLoadAndSaveBase : MonoBehaviour
    {
        [Header("�n�x�s�����")]
        public GoldManager goldManager;
        public Transform player;

        #region ��k�G���}�ä��\�Ƽg
        /// <summary>
        /// �x�s���
        /// </summary>
        public virtual void SaveData()
        {

        }

        /// <summary>
        /// ���J���
        /// </summary>
        public virtual void LoadData()
        {

        }
        #endregion
    }
}
