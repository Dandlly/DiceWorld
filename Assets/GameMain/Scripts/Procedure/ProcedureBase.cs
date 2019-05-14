/***
 *	 Company name（公司名）:HanJoy
 *   Title（名字）:小岛游戏开发
 *   Edition（版本）:v1.0.0
 *   Description（脚本内容）:
 *   Author（创建者）:	
 *	 Data（创建时间）:	
 *   Modify(修改日期):
***/

namespace IsletGame
{
	public abstract class ProcedureBase : GameFramework.Procedure.ProcedureBase {
        public abstract bool UseNativeDialog
        {
            get;
        }
	}
}


