using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEventHandler : MonoBehaviour
{
    public EAnimationActionEvent Event;

    public void TriggerEvent (EAnimationAction actionType) {
        Event?.Invoke(actionType);
    }
}
