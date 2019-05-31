using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Resource;
using UnityEngine.UI;

namespace IsletGame
{
	public class BuildingFun : UGuiForm
    {
       
        Sprite m_sprite = null;
        string mapName = "SC";
        int t_levelNum = 0;
        int a_levelNum = 0;
        int c_levelNum = 0;
        int b_levelNum = 0;
        int g_levelNum = 0;
        public GameObject trafficObj;
        public GameObject agriObj;
        public GameObject cityObj;
        public GameObject barrackObj;
        public GameObject granaryObj;

        private void Update()
        {
            //  Map_level();
        }

        public void Close_Allbtn() 
        {
            //gameObject.GetComponent<BuildingMenu>().Close_alllveelbtn();
        }

        /// <summary>
        /// 升级运输交通建筑方法
        /// </summary>
        public void Traffic_Level_Fun()
        {
            if (t_levelNum<5)
            {
                t_levelNum++;//获取当前等级
                AddBuilding("Traffic", t_levelNum, trafficObj);
                Close_Allbtn();
            }
            Map_level();
        }

        /// <summary>
        /// 升级田地建筑方法
        /// </summary>
        public void Agri_Level_Fun()
        {
            if (a_levelNum<5)
            {
                a_levelNum++;//获取当前等级
                AddBuilding("Agri", a_levelNum, agriObj);
                Close_Allbtn();
            }
            Map_level();
        }

        /// <summary>
        /// 升级主城建筑方法
        /// </summary>
        public void City_Level_Fun()
        {
            if (c_levelNum<5)
            {
                c_levelNum++;//获取当前等级
                AddBuilding("City", c_levelNum, cityObj);
                Close_Allbtn();
            }
            Map_level();
        }

        /// <summary>
        /// 升级兵营建筑方法
        /// </summary>
        public void Barracks_Level_Fun()
        {
            if (b_levelNum<5)
            {
                b_levelNum++;//获取当前等级
                AddBuilding("Barracks", b_levelNum, barrackObj);
                Close_Allbtn();
            }
            Map_level();
        }

        /// <summary>
        /// 升级粮仓建筑方法
        /// </summary>
        public void Granary_Level_Fun()
        {
            if (g_levelNum<5)
            {
                g_levelNum++;//获取当前等级
                AddBuilding("Granary", g_levelNum, granaryObj);
                Close_Allbtn();
            }
            Map_level();
        }

        /// <summary>
        /// 建筑升级
        /// </summary>
        /// <param name="buildingName">要升级建筑的名字</param>
        /// <param name="levelNum">升级等级</param>
        /// <param name="building">要升级的obj</param>
        public void AddBuilding(string buildingName,int levelNum,GameObject building)
        {
            string spriteName = mapName + buildingName + levelNum;
            LoadSprite(spriteName, building);           
        }

        /// <summary>
        /// 获取建筑Sprite
        /// </summary>
        /// <param name="matName">材质名字</param>
        /// <param name="entity">实体</param>
        private void LoadSprite(string spriteName, GameObject building)
        {
            GameEntry.Resource.LoadAsset(AssetUtility.GetSpriteAsset(spriteName), new LoadAssetCallbacks(
              (assetName, asset, duration, userData) =>
              {
                  Texture2D tex = (Texture2D)asset;
                  m_sprite = Sprite.Create(tex, new Rect(0,0, tex.width,tex.height),new Vector2(0,0));
                  building.GetComponent<Image>().sprite = m_sprite;
              },
              (assetName, status, errorMessage, userData) =>
              {
                  Log.Error("Can not load Sprite '{0}' from '{1}' with error message '{2}'.", spriteName, assetName, errorMessage);
              }));
        }

        private void Map_level()
        {
            if ((t_levelNum % 5 == 0 && t_levelNum != 0) && 
                (a_levelNum % 5 == 0 && a_levelNum != 0) && 
                (b_levelNum % 5 == 0 && b_levelNum != 0) && 
                (c_levelNum % 5 == 0 && c_levelNum != 0) && 
                (g_levelNum % 5 == 0 && g_levelNum != 0))
            {
                t_levelNum = a_levelNum = b_levelNum = c_levelNum = g_levelNum = 0;
                Debug.Log(mapName);
            }
        }

    }
}
