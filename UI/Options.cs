using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject _optionsObj;

    private void Awake()
    {
        _optionsObj.SetActive(false);
    }

    public void OptionUIActive(bool active)
    {
        _optionsObj.SetActive(active);
        Time.timeScale = 1;
    }
}
