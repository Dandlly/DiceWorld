using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace IsletGame
{
	public class DiceLogic : Entity
	{
        //是否静止 
        [SerializeField]
        private bool isSuspend = false;
        //是否跳动
        [SerializeField]
        private bool isJump= false;
        //冲击力
        [SerializeField]
        private float force=400f;

        public void Awake()
        {
            Dicemove();
        }

        private void Update()
        {
            IsSuspend();
          
        }
        private void FixedUpdate()
        {
        
            if (SlidingCon._instance.DiceIsMove&&!isJump)
            {
                Log.Debug("骰子滑动成功");
                Dicemove();
            }
        }

        /// <summary>
        /// 转动代码
        /// </summary>
        public void Dicemove()
        {
            isSuspend = true;
            Vector3 torquePosition = new Vector3(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));
            GetComponent<Rigidbody>().AddForce(Vector3.up * force);//给一个力往上
            GetComponent<Rigidbody>().AddTorque(torquePosition);//随意方向          
            GetComponent<Rigidbody>().maxAngularVelocity = 30;//增加速度               
            isJump = true;
        }

        /// <summary>
        /// 改变下坠速度
        /// </summary>
        public void IsSuspend()
        {
            if (!isSuspend)
            {
                GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                //加速坠落
                Physics.gravity = new Vector3(0, -40, 0);
                GetComponent<Rigidbody>().useGravity = true;
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Plane")
            {
                SlidingCon._instance.DiceIsMove = false;
                isJump = false;
            }
        }

        /// <summary>
        /// 卡45度
        /// </summary>
        /// <param name="dice"></param>
        public void StuckDegrees(GameObject dice)
        {
            if (((int)dice.transform.localEulerAngles.x == 138 || (int)dice.transform.localEulerAngles.x == 133)
                || ((int)dice.transform.localEulerAngles.x == 48 || (int)dice.transform.localEulerAngles.x == 43)
                || ((int)dice.transform.localEulerAngles.x == 318 || (int)dice.transform.localEulerAngles.x == 313)
                || ((int)dice.transform.localEulerAngles.x == 228 || (int)dice.transform.localEulerAngles.x == 223))

            {
                transform.Rotate(20, 0, 0);
            }
            if (((int)dice.transform.localEulerAngles.z == 48 || (int)dice.transform.localEulerAngles.z == 43)
                || ((int)dice.transform.localEulerAngles.z == 318 || (int)dice.transform.localEulerAngles.z == 313)
                || ((int)dice.transform.localEulerAngles.z == 228 || (int)dice.transform.localEulerAngles.z == 223)
                || ((int)dice.transform.localEulerAngles.z == 228 || (int)dice.transform.localEulerAngles.z == 223))
            {
                transform.Rotate(0, 0, 20);
            }
        }

      
    }
}
