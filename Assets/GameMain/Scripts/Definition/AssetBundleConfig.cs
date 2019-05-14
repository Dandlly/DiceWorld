using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Editor.AssetBundleTools;

namespace Assets.GameMain.Scripts.Definition
{
   static class AssetBundleConfig
    {
        [UnityGameFramework.Editor.AssetBundleTools.AssetBundleBuilderConfigPath]
        public static string AssetBundleBuilderConfig =
    Utility.Path.GetCombinePath(Application.dataPath, "GameMain/Configs/AssetBundleBuilder.xml");

        [AssetBundleEditorConfigPath]
        public static string AssetBundleEditorConfig =
            Utility.Path.GetCombinePath(Application.dataPath, "GameMain/Configs/AssetBundleEditor.xml");

        [AssetBundleCollectionConfigPath]
        public static string AssetBundleCollectionConfig =
            Utility.Path.GetCombinePath(Application.dataPath, "GameMain/Configs/AssetBundleCollection.xml");

    }
}
