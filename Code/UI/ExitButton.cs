using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour, IUIButton
{
    public void Click()
    {
        Application.Quit();
    }
}
