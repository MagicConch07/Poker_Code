using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossHpBar : MonoBehaviour
{
    [SerializeField] private GameObject[] _chipPrefab;
    [SerializeField] private RectTransform _chipTrm;
    private BossHealth _bossHealth;
    private Image[] _chips;
    private Transform _child;

    private int _hpIndex;

    private void Start()
    {
        _child = transform.GetChild(0);
        SettingHp(); 
        _chips = _child.GetComponentsInChildren<Image>();
        
        _hpIndex = _chips.Length - 1;
        InitHp();
    }

    public void ConnectAction(BossHealth boss)
    {
        _bossHealth = boss;
        _bossHealth.HitEvent += DecreaseHp;
    }

    public void SetAction(BossHealth boss)
    {
        boss.HitEvent -= DecreaseHp;
    }

    private void OnDestroy()
    {
        _bossHealth.HitEvent -= DecreaseHp;
    }

    private void SettingHp()
    {   
        for (int i = 0; i < 100; ++i)
        {
            int rand = Random.Range(0, _chipPrefab.Length);
            GameObject obj = Instantiate(_chipPrefab[rand], _child);
            obj.transform.localPosition += new Vector3(-12.5f + (i * 84), obj.transform.localPosition.y, obj.transform.localPosition.z);
        }
    }

    public void InitHp()
    {
        foreach (Image chip in _chips)
        {
            chip.enabled = true;
        }
        
        _hpIndex = _chips.Length - 1;
    }
    
    public void DecreaseHp(int damage)    
    {
        if (_hpIndex <= 0)
        {
            Debug.Log("보스 체력 끝");
        }
        else
        {
            _chips[_hpIndex].enabled = false;
            _hpIndex--;
        }
    }
}
