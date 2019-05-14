using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginTransparent : MonoBehaviour
{
    public GameObject quickly;

    private void Update()
    {
            DoTweenFun.AlphaFun(gameObject, quickly);

    }

}
