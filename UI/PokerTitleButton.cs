using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerTitleButton : MonoBehaviour, IUIButton
{
    private AudioSource _pokerSound;
    
    private void Awake()
    {
        _pokerSound = GetComponent<AudioSource>();
    }

    public void Click()
    {
        _pokerSound.Play();
    }
}
