using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWinCardBattle : MonoBehaviour
{
    [SerializeField] private UIPokerBattle _pokerBattle;
    [SerializeField] private TextMeshProUGUI _winner;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private UIBossCard _uiBossCard;
    [SerializeField] private SelectCard _selectCard;

    private void Awake()
    {
        PokerBattle.Instance.OnBattleFinished += HandleFin;
    }

    private void OnDestroy()
    {
        PokerBattle.Instance.OnBattleFinished -= HandleFin;
    }

    private void HandleFin(PokerAttacker name, string win, string arg3, int user)
    {
        if (name == null)
        {
            Debug.Log("adsfadsfasfasdfasdfasdfadsfa");
            _winText.text = "Draw";
            _winner.text = "";
        }
        else if (user == 2)
        {
            Debug.Log("adsfasdfafadfasdfasdfasfasdfa");
            _winText.text = "WIN";
            _winner.text = "Player";
        }
        else if (user == 1)
        {
            Debug.Log("dsafasfadsfasdfasdfadsfasfasdf");
            _winText.text = "WIN";
            _winner.text = "Boss";
        }
    }

    public void EndCorountine()
    {
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        _pokerBattle.EndDraw();
        Boss boss = FindObjectOfType<Boss>();
        boss.StartPattern();
        _uiBossCard.ClearCards();
        _selectCard.SetCard();
    }
}
