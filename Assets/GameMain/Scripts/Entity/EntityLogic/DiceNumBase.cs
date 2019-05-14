using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

namespace IsletGame
{
	public class DiceNumBase : Dice
	{
        protected override Vector3 HitVector(int side)
        {
            switch (side)
            {
                case 1: return new Vector3(0F, 0F, 1F);
                case 2: return new Vector3(0F, -1F, 0F);
                case 3: return new Vector3(-1F, 0F, 0F);
                case 4: return new Vector3(1F, 0F, 0F);
                case 5: return new Vector3(0F, 1F, 0F);
                case 6: return new Vector3(0F, 0F, -1F);
            }
            return Vector3.zero;
        }
    }
}
