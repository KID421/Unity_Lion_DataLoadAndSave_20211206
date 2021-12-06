using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 採金礦管理器
    /// </summary>
    public class GoldManager : MonoBehaviour
    {
        #region 欄位：公開
        [Header("採礦半徑"), Range(0, 10)]
        public float radius = 3.5f;
        [Header("採礦按鍵")]
        public KeyCode keyGold = KeyCode.E;
        [Header("目標圖層")]
        public LayerMask layerTarget;
        [Header("金幣數量")]
        public Text textCoin;
        [HideInInspector]
        public int goldCount;
        #endregion

        #region 欄位：私人
        #endregion

        #region 屬性：私人
        /// <summary>
        /// 按下採礦按鍵
        /// </summary>
        private bool inputGold { get => Input.GetKeyDown(keyGold); }
        /// <summary>
        /// 目標是否在半徑內
        /// </summary>
        private bool targetInRadius { get => Physics2D.OverlapCircle(transform.position, radius, layerTarget); }
        #endregion

        #region 事件
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.8f, 0.7f, 0.3f, 0.35f);
            Gizmos.DrawSphere(transform.position, radius);
        }

        private void Update()
        {
            GetGold();
        }
        #endregion

        #region 方法：私人
        /// <summary>
        /// 採礦
        /// </summary>
        private void GetGold()
        {
            if (inputGold && targetInRadius)
            {
                goldCount++;
                textCoin.text = "金幣數量：" + goldCount;
            }
        }
        #endregion

        #region 方法：公開
        /// <summary>
        /// 更新資料
        /// </summary>
        public void UpdateData()
        {
            textCoin.text = "金幣數量：" + goldCount;
        }
        #endregion
    }
}

