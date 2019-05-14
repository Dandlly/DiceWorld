/***
 *	 Company name（公司名）:HanJoy
 *   Title（名字）:小岛游戏开发
 *   Edition（版本）:v1.0.0
 *   Description（脚本内容）:
 *   Author（创建者）:	
 *	 Data（创建时间）:	
 *   Modify(修改日期):
***/

using GameFramework;

namespace IsletGame
{
	public static class AssetUtility
    {
        /// <summary>
        /// 获取配置资源的完整路径
        /// </summary>
        public static string GetConfigAsset(string assetName, LoadType loadType)
        {
            return Utility.Text.Format("Assets/GameMain/Configs/{0}.{1}", assetName, loadType == LoadType.Text ? "txt" : "bytes");
        }

        /// <summary>
        /// 获取数据表资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetDataTableAsset(string assetName, LoadType loadType)
        {
            return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", assetName, loadType == LoadType.Text ? "txt" : "bytes");
        }

        /// <summary>
        /// 获取字典资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetDictionaryAsset(string assetName, LoadType loadType)
        {
            return Utility.Text.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.{2}", GameEntry.Localization.Language.ToString(), assetName, loadType == LoadType.Text ? "xml" : "bytes");

        }

        /// <summary>
        /// 获取字体资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Fonts/{0}.ttf", assetName);
        }

        /// <summary>
        /// 获取场景资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        /// <summary>
        /// 获取音乐资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Music/{0}.mp3", assetName);
        }

        /// <summary>
        /// 获取声音音效资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetWavSoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Sounds/{0}.wav", assetName);
        }

        /// <summary>
        /// 获取实体资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetEntityAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Entities/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取界面资源资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/UI/UIForms/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取界面音效资源的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/UI/UISounds/{0}.wav", assetName);
        }

        /// <summary>
        /// 获取材质的完整路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetMaterialAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Materials/{0}.mat", assetName);
        }


    }
}


