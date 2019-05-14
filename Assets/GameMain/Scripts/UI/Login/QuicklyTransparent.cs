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
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace IsletGame{
	public class QuicklyTransparent : UGuiForm {
        private Button enterBtn;
        public GameObject login_Obj;

        private void Awake()
        {
            enterBtn = transform.Find("EnterButton").GetComponent<Button>();
        }
        private void Start()
        {
            enterBtn.onClick.AddListener(Quicklysuccessful);
        }
        private void Update()
        {
            DoTweenFun.AlphaFun(gameObject, login_Obj);

        }
        public void Quicklysuccessful()
        {
            login_Obj.SetActive(true);
            gameObject.SetActive(false);
        }
     
    }
}


