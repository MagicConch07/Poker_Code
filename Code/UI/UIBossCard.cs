using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossCard : MonoBehaviour
{
    [SerializeField] private Image[] _cardImage;

    private Boss _boss;

    private int _cardIndex = 0;

    private void Awake()
    {
        ClearCards();
    }

    public void ConnectedBoss(Boss boss)
    {
        _boss = boss;
        _boss.OnCardSelected += HandleCards;
    }

    public void SetBoss(Boss boss)
    {
        _boss = boss;
        _boss.OnCardSelected -= HandleCards;
    }

    private void HandleCards(Card card)
    {
        if (_cardIndex <= 5)
        {
            _cardImage[_cardIndex].enabled = true;
            _cardImage[_cardIndex].sprite = card.front.sprite;
            _cardIndex++;
        }
    }

    public void ClearCards()
    {
        foreach (var card in _cardImage)
        {
            card.enabled = false;
        }

        _cardIndex = 0;
    }
}
