using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINextStage : MonoBehaviour, IUIButton
{
    public void Click()
    {
        StageManager.Instance.StageClear();
        StageManager.Instance.NextStage();
    }
}
