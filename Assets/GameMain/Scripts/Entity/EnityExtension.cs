
using GameFramework.DataTable;
using UnityGameFramework.Runtime;
using System;
using GameMain.Scripts.DataTable;

namespace IsletGame
{
	public static class EnityExtension 
	{
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
         private static int s_SerialId = 0;

        /// <summary>
        /// 获取实体逻辑脚本
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity)entity.Logic;
        }

        /// <summary>
        /// 显示实体
        /// </summary>
        /// <param name="logicType">实体逻辑类型</param>
        /// <param name="entityGroup">实体组</param>
        /// <param name="data">实体数据</param>
        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data是空的");
                return;
            }
            //获取列表 
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            //根据实体数据对象的类型ID，获取对应的实体数据表行
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);         
            if (drEntity == null)
            {
                Log.Warning("无法从数据表加载实体id:'{0}'", data.TypeId.ToString());
                return;
            }
            //显示实体
            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, data);
        }

        /// <summary>
        /// 显示地板
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="data">实体数据</param>
        public static void ShowPlane(this EntityComponent entityComponent,PlaneData data)
        {
            entityComponent.ShowEntity(typeof(PlaneLogin), "Plane" ,data);
        }

        /// <summary>
        /// 显示骰子
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="data">实体数据</param>
        public static void ShowDice(this EntityComponent entityComponent,DiceData data)
        {
            entityComponent.ShowEntity(typeof(DiceLogic), "Dice", data);
        }

        /// <summary>
        /// 生成序列ID
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <returns></returns>
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }
    }
}
