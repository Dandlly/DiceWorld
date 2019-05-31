using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;

namespace IsletGame
{
	public  class GameBase 
	{
        private Dice dice = null;

        public virtual void Initialize()
        {
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
            GameEntry.Entity.ShowPlane(new PlaneData(GameEntry.Entity.GenerateSerialId(), 20001)
            {
                Position = Vector3.one,
            });

            GameEntry.Entity.ShowDice(new DiceData(GameEntry.Entity.GenerateSerialId(), 10001)
            {
                Position = new Vector3(-1.7f, 1.5f, 0f),
                MaterialName = "Atk",
                Name = "Dice",
            });
            GameEntry.Entity.ShowDice(new DiceData(GameEntry.Entity.GenerateSerialId(), 10001)
            {
                Position = new Vector3(0f, 1.5f, 0f),
                Name = "Dice",
                MaterialName = "Atk",
            });
            GameEntry.Entity.ShowDice(new DiceData(GameEntry.Entity.GenerateSerialId(), 10001)
            {
                Position = new Vector3(1.7f, 1.5f, 0f),
                Name = "Dice",
                MaterialName = "Def",
            });
            GameEntry.Entity.ShowDice(new DiceData(GameEntry.Entity.GenerateSerialId(), 10001)
            {
                Position = new Vector3(-1.7f, 1.5f, -1.6f),
                Name = "Dice",
                MaterialName = "Def",
            });
            GameEntry.Entity.ShowDice(new DiceData(GameEntry.Entity.GenerateSerialId(), 10001)
            {
                Position = new Vector3(0f, 1.5f, -1.6f),
                Name = "Dice",
                MaterialName = "Luck",
            });
            GameEntry.Entity.ShowDice(new DiceData(GameEntry.Entity.GenerateSerialId(), 10001)
            { 
                Position = new Vector3(1.7f, 1.5f, -1.6f),
                Name = "Dice",
                MaterialName = "Luck",
            });
        }

        public virtual void Shutdown()
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
        }



        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.EntityLogicType==typeof(Dice))
            {
                dice = (Dice)ne.Entity.Logic;
            }
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }
    }
}
