using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeVar : MonoBehaviour
{
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        
        // Init
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        SoundManager.Instance.SetMainVolume(_slider.value);
    }
}
