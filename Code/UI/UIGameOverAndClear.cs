using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverAndClear : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _ClearOver;
    [SerializeField] private PlayerHealth _playerHealth;
    private BossHealth _bossHealth;

    private void Awake()
    {
        _gameOver.SetActive(false);
        _ClearOver.SetActive(false);
    }

    private void Start()
    {
        _playerHealth.DeadEvent += GameOver;
    }

    public void GetHp(BossHealth boss)
    {
        _bossHealth = boss;
        _bossHealth.DeadEvent += Clear;
    }

    public void SetHp(BossHealth boss)
    {
        _bossHealth = boss;
        _bossHealth.DeadEvent -= Clear;
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
    }

    public void Clear()
    {
        _ClearOver.SetActive(true);
    }
}
