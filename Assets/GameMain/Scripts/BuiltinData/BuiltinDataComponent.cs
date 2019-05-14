/***
 *	 Company name（公司名）:HanJoy
 *   Title（名字）:小岛游戏开发
 *   Edition（版本）:v1.0.0
 *   Description（脚本内容）:内装式数据组件
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
	public class BuiltinDataComponent : GameFrameworkComponent
    {
        //构建信息文本资产
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;

        //默认字典文本资产
        [SerializeField]
        private TextAsset m_DefaultDictionaryTextAsset = null;

        private BuildInfo m_BuildInfo = null;

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }

        //初始化构建信息
        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("无法找到或为空的生成信息。");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Warning("解析构建信息失败。");
                return;
            }
        }

        //初始化默认的字典
        public void InitDefaultDictionary()
        {
            if (m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("无法找到默认字典或为空。");
                return;
            }

            if (!GameEntry.Localization.ParseDictionary(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("解析默认字典失败。");
                return;
            }
        }
    }
}


