using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家資料
    /// 要轉為 JSON 的資料
    /// </summary>
    public class PlayerData
    {
        public int coin;
        public float posX;
        public float posY;
        public Quaternion angle;
        public float time;

        // 建構子：無傳回並且名稱與類別一樣的方法
        // 會在此類別成為物件時執行一次，處理初始化
        /// <summary>
        /// 建立玩家資料物件並賦予值
        /// </summary>
        /// <param name="coin">金幣</param>
        /// <param name="posX">座標 X</param>
        /// <param name="posY">座標 Y</param>
        public PlayerData(int coin, float posX, float posY)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;
        }

        /// <summary>
        /// 建立玩家資料物件並賦予值
        /// </summary>
        /// <param name="coin">金幣</param>
        /// <param name="posX">座標 X</param>
        /// <param name="posY">座標 Y</param>
        /// <param name="angle">角度</param>
        /// <param name="time">時間</param>
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

