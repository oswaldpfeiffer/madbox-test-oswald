using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AnimatorUtil
{
    public static void ResetAnimatorTriggers(Animator anim)
    {
        foreach (var parameter in anim.parameters.Where(parameter => parameter.type == AnimatorControllerParameterType.Trigger))
        {
            anim.ResetTrigger(parameter.name);
        }
    }
}
