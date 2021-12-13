using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���a���
    /// �n�ର JSON �����
    /// </summary>
    public class PlayerData
    {
        public int coin;
        public float posX;
        public float posY;

        // �غc�l�G�L�Ǧ^�åB�W�ٻP���O�@�˪���k
        // �|�b�����O��������ɰ���@���A�B�z��l��
        /// <summary>
        /// �إߪ��a��ƪ���ýᤩ��
        /// </summary>
        /// <param name="coin">����</param>
        /// <param name="posX">�y�� X</param>
        /// <param name="posY">�y�� Y</param>
        public PlayerData(int coin, float posX, float posY)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;
        }
    }
}

