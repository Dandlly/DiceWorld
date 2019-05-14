using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Resource;

namespace IsletGame
{
	public abstract class Entity : EntityLogic
    {
        [SerializeField]
        private EntityData m_EntityData = null;
        private Material m_material = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EntityData = userData as EntityData;
            if (m_EntityData == null)
            {
                Log.Error("Entity data is invalid.");
                return;
            }
            CachedTransform.localPosition = m_EntityData.Position;
            CachedTransform.localRotation = m_EntityData.Rotation;
            //如果材质不等于null 才进去
            if (m_EntityData.MaterialName!=null)
            {
                LoadMaterial(m_EntityData.MaterialName, transform.gameObject);
            }
            CachedTransform.localScale =new Vector3(1,1,1);
        }    
        

        /// <summary>
        /// 获取材质
        /// </summary>
        /// <param name="matName">材质名字</param>
        /// <param name="entity">实体</param>
        private void LoadMaterial(string matName,GameObject entity)
        {
            GameEntry.Resource.LoadAsset(AssetUtility.GetMaterialAsset(matName), Constant.AssetPriority.MatAsset, new LoadAssetCallbacks(
              (assetName, asset, duration, userData) =>
              {
                  m_material =(Material) asset;
                  entity.GetComponent<Renderer>().material = m_material;
              },
              (assetName, status, errorMessage, userData) =>
              {
                  Log.Error("Can not load Mat '{0}' from '{1}' with error message '{2}'.", matName, assetName, errorMessage);
              }));
        }

    }
}
