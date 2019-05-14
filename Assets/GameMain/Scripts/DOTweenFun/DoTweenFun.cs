using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenFun : MonoBehaviour
{
    /// <summary>
    /// 透明过渡
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="gameObject_2"></param>
    public static void AlphaFun(GameObject A,GameObject B)
    {
        A.GetComponent<CanvasGroup>().DOFade(1, 2f);
        B.GetComponent<CanvasGroup>().DOFade(0, 1f);
    }

   
}
