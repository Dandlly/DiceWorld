/***
 *	 Company name（公司名）:HanJoy
 *   Title（名字）:小岛游戏开发
 *   Edition（版本）:v1.0.0
 *   Description（脚本内容）:
 *   Author（创建者）:	
 *	 Data（创建时间）:	
 *   Modify(修改日期):
***/

using GameFramework.DataTable;
using GameFramework.Event;
using GameMain.Scripts.DataTable;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace IsletGame
{
    public class ProcedureLogin : ProcedureBase
    {
        private bool m_PlayGame = false;
        private LoginMenu m_loginMenu = null;
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        public void StartPlay()
        {
            m_PlayGame = true;
        }

        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="procedureOwner"></param>
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);        
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, this);
        }

        /// <summary>
        /// 关闭状态
        /// </summary>
        /// <param name="procedureOwner"></param>
        /// <param name="isShutdown"></param>
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            if (m_loginMenu != null)
            {
                m_loginMenu.Close(isShutdown);
                m_loginMenu = null;
            }
        }

        /// <summary>
        /// update 每秒检测
        /// </summary>
        /// <param name="procedureOwner"></param>
        /// <param name="elapseSeconds"></param>
        /// <param name="realElapseSeconds"></param>
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_PlayGame)
            {
                procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Main"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }

        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            m_loginMenu = (LoginMenu)ne.UIForm.Logic;
        }
    }
}


