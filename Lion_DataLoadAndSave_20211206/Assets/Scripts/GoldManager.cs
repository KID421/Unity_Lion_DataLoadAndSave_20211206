using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// �Ī��q�޲z��
    /// </summary>
    public class GoldManager : MonoBehaviour
    {
        #region ���G���}
        [Header("���q�b�|"), Range(0, 10)]
        public float radius = 3.5f;
        [Header("���q����")]
        public KeyCode keyGold = KeyCode.E;
        [Header("�ؼйϼh")]
        public LayerMask layerTarget;
        [Header("�����ƶq")]
        public Text textCoin;
        [HideInInspector]
        public int goldCount;
        #endregion

        #region ���G�p�H
        #endregion

        #region �ݩʡG�p�H
        /// <summary>
        /// ���U���q����
        /// </summary>
        private bool inputGold { get => Input.GetKeyDown(keyGold); }
        /// <summary>
        /// �ؼЬO�_�b�b�|��
        /// </summary>
        private bool targetInRadius { get => Physics2D.OverlapCircle(transform.position, radius, layerTarget); }
        #endregion

        #region �ƥ�
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

        #region ��k�G�p�H
        /// <summary>
        /// ���q
        /// </summary>
        private void GetGold()
        {
            if (inputGold && targetInRadius)
            {
                goldCount++;
                textCoin.text = "�����ƶq�G" + goldCount;
            }
        }
        #endregion

        #region ��k�G���}
        /// <summary>
        /// ��s���
        /// </summary>
        public void UpdateData()
        {
            textCoin.text = "�����ƶq�G" + goldCount;
        }
        #endregion
    }
}

