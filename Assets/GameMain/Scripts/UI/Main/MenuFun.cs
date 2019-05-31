
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IsletGame {
    public class MenuFun : UGuiForm
    {
        private Button shop_btn;
        private Button friend_btn;
        private Button rank_btn;
        private Button email_btn;
        private Button settinng_btn;
        private Button building_btn;

        private Button shopClose_btn;
        private Button friendClose_btn;
        private Button rankClose_btn;
        private Button emailClose_btn;
        private Button settinngClose_btn;

        private GameObject shop_Obj;
        private GameObject friend_Obj;
        private GameObject rank_Obj;
        private GameObject email_Obj;
        private GameObject setting_Obj;

        private bool isShow=false;
        public static bool isMenuShow=false;

        private void Awake()
        {
            //获取组件
            shop_btn = transform.Find("MenuForm/MenuGroup/Shop").GetComponent<Button>();
            friend_btn = transform.Find("MenuForm/MenuGroup/Feiend").GetComponent<Button>();
            rank_btn = transform.Find("MenuForm/MenuGroup/Rank").GetComponent<Button>();
            email_btn = transform.Find("MenuForm/MenuGroup/Email").GetComponent<Button>();
            settinng_btn = transform.Find("MenuForm/MenuGroup/Setting").GetComponent<Button>();
            building_btn = transform.Find("BuildingBtn").GetComponent<Button>();

            shopClose_btn = transform.Find("MenuFun/Shop/Close").GetComponent<Button>();
            friendClose_btn = transform.Find("MenuFun/Friends/Close").GetComponent<Button>();
            rankClose_btn = transform.Find("MenuFun/Rank/Close").GetComponent<Button>();
            emailClose_btn = transform.Find("MenuFun/Email/Close").GetComponent<Button>();
            settinngClose_btn = transform.Find("MenuFun/Setting/Close").GetComponent<Button>();

            shop_Obj = transform.Find("MenuFun/Shop").gameObject;
            friend_Obj = transform.Find("MenuFun/Friends").gameObject;
            rank_Obj = transform.Find("MenuFun/Rank").gameObject;
            email_Obj = transform.Find("MenuFun/Email").gameObject;
            setting_Obj = transform.Find("MenuFun/Setting").gameObject;
           
        }

        private void Start()
        {
            //监听按钮
            shop_btn.onClick.AddListener(ShopFun);
            friend_btn.onClick.AddListener(FeriendFun);
            rank_btn.onClick.AddListener(RankFun);
            email_btn.onClick.AddListener(EmailFun);
            settinng_btn.onClick.AddListener(SettingFun);

            shopClose_btn.onClick.AddListener(ShopFun);
            friendClose_btn.onClick.AddListener(FeriendFun);
            rankClose_btn.onClick.AddListener(RankFun);
            emailClose_btn.onClick.AddListener(EmailFun);
            settinngClose_btn.onClick.AddListener(SettingFun);
        }

        private void ShopFun()
        {
            if (isShow)
            {
                shop_Obj.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                isShow = false;
            }
            else
            {
                isMenuShow = true;
                shop_Obj.GetComponent<DOTweenAnimation>().DOPlayForward();
                isShow = true;
            }
        }

        private void FeriendFun()
        {
            if (isShow)
            {
                friend_Obj.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                isShow = false;
            }
            else
            {
                isMenuShow = true;
                friend_Obj.GetComponent<DOTweenAnimation>().DOPlayForward();
                isShow = true;
            }
        }

        private void RankFun()
        {
            if (isShow)
            {
                rank_Obj.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                isShow = false;
            }
            else
            {
                isMenuShow = true;
                rank_Obj.GetComponent<DOTweenAnimation>().DOPlayForward();
                isShow = true;
            }
        }

        private void EmailFun()
        {
            if (isShow)
            {
                email_Obj.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                isShow = false;
            }
            else
            {
                isMenuShow = true;
                email_Obj.GetComponent<DOTweenAnimation>().DOPlayForward();
                isShow = true;
            }
        }

        private void SettingFun()
        {
            if (isShow)
            {
                setting_Obj.GetComponent<DOTweenAnimation>().DOPlayBackwards();
                isShow = false;
            }
            else
            {
                isMenuShow = true;
                setting_Obj.GetComponent<DOTweenAnimation>().DOPlayForward();
                isShow = true;
            }
        }
    }
}
