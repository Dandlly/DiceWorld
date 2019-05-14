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
using UnityGameFramework.Runtime;
using GameFramework;

namespace IsletGame
{
	public static class LocalicationExtension  {
        public static void LoadDictionary(this LocalizationComponent localizationComponent, string dictionaryName, LoadType loadType, object userData = null)
        {
            if (string.IsNullOrEmpty(dictionaryName))
            {
                Log.Warning("Dictionary name is invalid.");
                return;
            }

            localizationComponent.LoadDictionary(dictionaryName, AssetUtility.GetDictionaryAsset(dictionaryName, loadType), loadType, Constant.AssetPriority.DictionaryAsset, userData);
        }
    }
}


