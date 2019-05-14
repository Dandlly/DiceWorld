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
	public class LoginMenu : UGuiForm {
        private ProcedureLogin m_procedureLogin=null;

        private Button quickly_Btn;
        private GameObject login_Obj;
        private GameObject quickly_Obj;
        private void Awake()
        {
            //绑定按钮
            quickly_Btn = transform.Find("Login/Baseboard/Quick registration").GetComponent<Button>();

            //绑定Obj
            login_Obj = transform.Find("Login").gameObject;
            quickly_Obj = transform.Find("QuicklyForm").gameObject;

            //激活
            login_Obj.SetActive(true);
        }

        private void Start()
        {
            //倾听事件
            quickly_Btn.onClick.AddListener(OnQuicklySignChilk);

        }

        public void OnPlayGameChilk()
        {
            m_procedureLogin.StartPlay();
        }

        public void OnFacebookChilk()
        {
            Debug.Log("Facebook");
        }

        public void OnVisitorLoginChilk()
        {
            Debug.Log("游客登录");
            m_procedureLogin.StartPlay();
        }

        public void OnForgetPasswordChilk()
        {
            Debug.Log("忘记密码");
        }

        public void OnQuicklySignChilk()
        {
            login_Obj.SetActive(false);          
            quickly_Obj.SetActive(true);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_procedureLogin = (ProcedureLogin)userData;
            if (m_procedureLogin == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }
        }

        protected override void OnClose(object userData)
        {
            m_procedureLogin = null;
            base.OnClose(userData);
        }
    }
}


