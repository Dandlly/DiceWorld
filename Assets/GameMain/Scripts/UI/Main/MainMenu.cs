/***
 *	 Company name（公司名）:HanJoy
 *   Title（名字）:小岛游戏开发
 *   Edition（版本）:v1.0.0
 *   Description（脚本内容）:
 *   Author（创建者）:	
 *	 Data（创建时间）:	
 *   Modify(修改日期):
***/

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IsletGame{
	public class MainMenu : UGuiForm
    {
        private Button menu_Btn;
        private Button signIn_Btn;
        private Button topUp_Btn;
        private Button firstCharge_Btn;
        private Button building_Btn;

        private GameObject menu;
        private GameObject buliding;

        private bool menu_isShow = false;

        private void Awake()
        {
            menu_Btn = transform.Find("MenuFun/MenuBtn").GetComponent<Button>();
            building_Btn = transform.Find("BuildingBtn").GetComponent<Button>();
            signIn_Btn = transform.Find("Functions/Sign_btn").GetComponent<Button>();
            topUp_Btn = transform.Find("Functions/TopUp_btn").GetComponent<Button>();
            firstCharge_Btn = transform.Find("Functions/FirstCharge_btn").GetComponent<Button>();
            menu = transform.Find("MenuForm").gameObject;
            buliding = transform.Find("BuildingForm").gameObject;
        }

        private void Start()
        {
            menu_Btn.onClick.AddListener(Menu);
            signIn_Btn.onClick.AddListener(SignInFun);
            topUp_Btn.onClick.AddListener(TopUpFun);
            firstCharge_Btn.onClick.AddListener(FirstChargeFun);
            building_Btn.onClick.AddListener(BulidingFun);
        }

        private void Update()
        {          
            if (MenuFun.isMenuShow)
            {
                menu.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                menu_isShow = false;
                MenuFun.isMenuShow = false;
            }
        }

        public void Menu()
        {
            if (menu_isShow)
            {
                menu.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                menu_isShow = false;
                MenuFun.isMenuShow = false;
            }
            else
            {
                menu.GetComponent<DOTweenAnimation>().DOPlayForward();
                menu_isShow = true;
            }
        }

        public void SignInFun()
        {

        }

        public void TopUpFun()
        {

        }

        public void FirstChargeFun()
        {

        }

        public void BulidingFun()
        {
            buliding.GetComponent<DOTweenAnimation>().DOPlayForward();
        }
    }
}


