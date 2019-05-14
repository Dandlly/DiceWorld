/***
 *	 Company name（公司名）:HanJoy
 *   Title（名字）:小岛游戏开发
 *   Edition（版本）:v1.0.0
 *   Description（脚本内容）:
 *   Author（创建者）:	
 *	 Data（创建时间）:	
 *   Modify(修改日期):
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace IsletGame{
    public class SlidingCon : ScrollRect
    {
        public static SlidingCon _instance;
        public static SlidingCon Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new SlidingCon();
                }
                return _instance;
            }
        }

        private  float radius = 100;
        private bool isValid = false;
        public bool DiceIsMove { get; set; } = false;

        private new void Start()
        {
            _instance = this;
            radius = (transform as RectTransform).sizeDelta.x * 0.45f;
        }

        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            //获取摇杆，根据锚点的位置
            Vector2 pos = content.anchoredPosition;
            //判断能量是否够，如果为0怎么不能滑动
            if (true)
            {
                //判断是否滑动有效 是否大于半径
                if (pos.y>radius)
                {
                    isValid = true;
                }
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            //滑动有效然后骰子滑动
            if (isValid)
            {
                Log.Debug("骰子应该滑动");
                DiceIsMove = true;
                isValid = false;
            }

            //还原初始位置
            content.transform.localPosition = Vector3.zero;
        }

    }
}


