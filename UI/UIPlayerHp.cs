using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHp : MonoBehaviour
{
    [SerializeField] private Image _hp;
    [SerializeField]private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth.HitEvent += HandleHit;
    }

    private void OnDestroy()
    {
        _playerHealth.HitEvent -= HandleHit;
    }

    private void HandleHit(int damage)
    {
        float per = damage / 100f;

        _hp.fillAmount -= per;
    }
}
