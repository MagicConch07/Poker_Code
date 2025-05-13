using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEsc : MonoBehaviour
{
    [SerializeField] private GameObject _escUI;
    [SerializeField] private InputReader _input;

    private void Awake()
    {
        _input.SettingEvent += HandleSetting;
    }

    private void OnDestroy()
    {
        _input.SettingEvent -= HandleSetting;
    }

    private void HandleSetting(bool isActive)
    {
        _escUI.SetActive(isActive);

        if (isActive)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
