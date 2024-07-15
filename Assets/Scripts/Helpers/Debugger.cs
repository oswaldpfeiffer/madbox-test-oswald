using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.W)) EventBus.TriggerLevelWin();
        if (Input.GetKeyDown(KeyCode.F)) EventBus.TriggerLevelFail();
#endif
    }
}
