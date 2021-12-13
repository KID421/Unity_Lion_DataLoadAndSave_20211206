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
        public Quaternion angle;
        public float time;

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

        /// <summary>
        /// �إߪ��a��ƪ���ýᤩ��
        /// </summary>
        /// <param name="coin">����</param>
        /// <param name="posX">�y�� X</param>
        /// <param name="posY">�y�� Y</param>
        /// <param name="angle">����</param>
        /// <param name="time">�ɶ�</param>
        public PlayerData(int coin, float posX, float posY, Quaternion angle, float time)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;
            this.angle = angle;
            this.time = time;
        }
    }
}

