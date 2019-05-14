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

namespace IsletGame{
	public class LoginFun : MonoBehaviour {

        private GameObject m_login;
        private GameObject m_quickly;

        private Button m_enter;
        private Button m_sendSMS;
        private void Awake()
        {
            m_login = transform.Find("Login").GetComponent<GameObject>();
            m_quickly = transform.Find("Quickly").GetComponent<GameObject>();

            m_enter = transform.Find("Quickly/EnterButton").GetComponent<Button>();
            m_sendSMS = transform.Find("Quickly/SMSButton").GetComponent<Button>();
        }

        private void Start()
        {
            m_enter.onClick.AddListener(RegistrationBtn);
        }

        private void RegistrationBtn()
        {
            m_quickly.SetActive(false);
            m_login.SetActive(true);
        }

        public void RegisteredFun()
        {
            m_quickly.SetActive(true);
            m_login.SetActive(false);
        }
    }
}


