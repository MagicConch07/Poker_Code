using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPokerBattle : MonoBehaviour
{
    [SerializeField] private Image[] _playerCard;
    [SerializeField] private TextMeshProUGUI _playerText;
    [SerializeField] private Image[] _bossCard;
    [SerializeField] private TextMeshProUGUI _bossText;
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _winUi;

    private UIWinCardBattle _winBattle;

    private Boss _boss;

    private void Awake()
    {
        _winBattle = GetComponent<UIWinCardBattle>();
        _ui.SetActive(false);
        _winUi.SetActive(false);
        PokerBattle.Instance.OnStartBattle += HandleBattle;
        PokerBattle.Instance.OnBattleFinished += HandleFinished;
        PokerBattle.Instance.OnDataUp += HandleDataUp;
    }

    private void HandleDataUp(string boss, string player)
    {
        CardText(_bossText, boss);
        CardText(_playerText, player);
    }

    public void EndDraw()
    {
        _ui.SetActive(false);
        _winUi.SetActive(false);
    }

    private void HandleFinished(PokerAttacker winner, string winnerCard, string looserCard, int arg4)
    {
        StartCoroutine(Win());
    }

    private void HandleBattle()
    {
        _boss = FindObjectOfType<Boss>();
        _boss.StopPattern();
        _ui.SetActive(true);
        Player player = PlayerManager.Instance.player;
        CardSetting(_playerCard, player.deck);
        CardSetting(_bossCard, _boss.deck);
    }

    public void CardText(TextMeshProUGUI textOwner, string text)
    {
        if (text == "")
            textOwner.text = "조합 X";
        else
            textOwner.text = text;
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(5f);
        _ui.SetActive(false);
        _winUi.SetActive(true);
        _winBattle.EndCorountine();
    }

    public void CardSetting(Image[] cardOwner, List<Card> cards)
    {
        for (int i = 0; i < cardOwner.Length; ++i)
        {
            cardOwner[i].sprite = cards[i].front.sprite;
        }
    }
}
