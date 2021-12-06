using UnityEngine;

namespace KID
{
    /// <summary>
    /// 2D 角色控制器
    /// </summary>
    public class Controller2D : MonoBehaviour
    {
        #region 欄位：公開
        [Header("移動速度"), Range(0, 10)]
        public float speed = 3.5f;
        [Header("動畫參數")]
        public string parameterRun = "開關跑步";
        #endregion

        #region 欄位：私人
        private Rigidbody2D rig;
        private Animator ani;
        #endregion

        #region 屬性：私人
        /// <summary>
        /// 水平輸入值
        /// </summary>
        private float inputHorizontal { get => Input.GetAxis("Horizontal"); }
        #endregion

        #region 事件
        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            Flip();
            UpdateAnimation();
        }
        #endregion

        #region 方法：私人
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector2(speed * inputHorizontal, rig.velocity.y);
        }

        /// <summary>
        /// 更新動畫
        /// </summary>
        private void UpdateAnimation()
        {
            ani.SetBool(parameterRun, inputHorizontal != 0);
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            if (Mathf.Abs(inputHorizontal) < 0.1f) return;      // 水平值絕對值 < 0.1 不處理
            float yAngle = inputHorizontal > 0 ? 0 : 180;       // 水平值 > 0 角度 0 否則 180
            transform.eulerAngles = new Vector3(0, yAngle, 0);  // 更新歐拉角度
        }
        #endregion
    }
}

