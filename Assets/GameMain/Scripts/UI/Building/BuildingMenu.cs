using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using UnityEngine.UI;
using System;
using DG.Tweening;

namespace IsletGame
{
	public class BuildingMenu : UGuiForm
    {
        private Button main_Btn;
        private Button upgrade_btn;
        private GameObject allLevel_btn;

        private void Awake()
        {
            main_Btn = transform.Find("MainBtn").GetComponent<Button>();
            upgrade_btn = transform.Find("Upgrade_btn").GetComponent<Button>();

            allLevel_btn = transform.Find("AllLevel_btn").gameObject;
        }

        private void Start()
        {
            Close_alllveelbtn();
            main_Btn.onClick.AddListener(MainFun);
            upgrade_btn.onClick.AddListener(UpgradeFun);
        }

        public void Close_alllveelbtn()
        {
            allLevel_btn.SetActive(false);
        }

        private void UpgradeFun()
        {
            allLevel_btn.SetActive(true);
        }

        private void MainFun()
        {
            gameObject.GetComponent<DOTweenAnimation>().DOPlayBackwards();
        }
    }
}
