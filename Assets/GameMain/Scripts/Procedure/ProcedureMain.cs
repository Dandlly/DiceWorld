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
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.DataTable;
using GameMain.Scripts.DataTable;
using GameFramework.Event;

namespace IsletGame
{
	public class ProcedureMain : ProcedureBase
    {
        private GameBase m_CurrentGame ;
        private bool isGetEntity = false;
        public UnityGameFramework.Runtime.Entity[] entities = null;
        List<UnityGameFramework.Runtime.Entity> ts = new List<UnityGameFramework.Runtime.Entity>();
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            m_CurrentGame = new GameBase();
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            //打开UI
            GameEntry.UI.OpenUIForm(UIFormId.MainForm);
            GameEntry.UI.OpenUIForm(UIFormId.ShowForm);  
            //实例化骰子
            m_CurrentGame.Initialize();  
            

        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            //骰子的返回值
            AllDiceNum();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            m_CurrentGame.Shutdown();
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            base.OnLeave(procedureOwner, isShutdown);
        }

        /// <summary>
        /// 检查骰子是否静止了
        /// </summary>
        /// <returns></returns>
        private bool AllDiceIsSheep()
        {
            //这里因为骰子永远只有6个，所以我锁死了
            if (entities[0].GetComponent<Rigidbody>().IsSleeping()&&
                entities[1].GetComponent<Rigidbody>().IsSleeping()&&
                entities[2].GetComponent<Rigidbody>().IsSleeping()&&
                entities[3].GetComponent<Rigidbody>().IsSleeping()&&
                entities[4].GetComponent<Rigidbody>().IsSleeping()&&
                entities[5].GetComponent<Rigidbody>().IsSleeping())
            {
                return true;
            }          
            return false;
        }

        private void AllEntites()
        {
            if (!isGetEntity)
            {
                GetDiceEntities();
                if (entities.Length == 6)
                {
                    isGetEntity = true;
                }
            }
        }

        /// <summary>
        /// 获取骰子的实体(排除地板这个实体)
        /// </summary>
        private void GetDiceEntities()
        {
            entities=GameEntry.Entity.GetEntities("Assets/GameMain/Entities/Dice.prefab");          
        }

        /// <summary>
        /// 获取全部骰子数值
        /// </summary>
        private void AllDiceNum()
        {
            AllEntites();
            if (isGetEntity)
            {
                if (AllDiceIsSheep())
                {
                    if (entities.Length == 6)
                    {
                        foreach (var item in entities)
                        {
                            if (item.GetComponent<DiceNumBase>().value != 0)
                            {
                                //这里完成获取每个骰子的返回值（传入粒子系统完成粒子特效显示）
                              //  Debug.Log(item.GetComponent<DiceNumBase>().value);
                            }
                        }
                    }
                }
            }                                       
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }           
        }
    }
}


