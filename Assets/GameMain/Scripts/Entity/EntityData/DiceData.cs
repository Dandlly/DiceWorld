using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

namespace IsletGame
{
    [SerializeField]
	public class DiceData : EntityData
    {
        [SerializeField]
        private string m_Name = null;

        public DiceData(int entityId,int typeId):base(entityId,typeId)
        {

        }


        /// <summary>
        /// 名称。
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
    }
}
