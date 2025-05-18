using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SelectCard : MonoBehaviour
{
    [SerializeField] private MovingCard _cardPrefab;
    [SerializeField] private Transform[] _cardPosition;

    private Dictionary<int, MovingCard> _movingCards = new Dictionary<int, MovingCard>();

    private Player _player;
    private AgentMovement _agentMovement;

    public Ease ease;
    private int posIndex = 0;

    private int _cardIndex = 0;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _player.OnCardSelected += HandlePick;
        _cardIndex = 0;
    }

    private void OnDestroy()
    {
        _player.OnCardSelected -= HandlePick;
    }

    private void HandlePick(Card card)
    {
        GetCard(card.front.sprite);
    }

    public void GetCard(Sprite cardSprite)
    {
        if (_cardIndex < 5)
        {
            MovingCard card = Instantiate(_cardPrefab, _player.transform.position, Quaternion.identity);
            SpriteRenderer spr = card.GetComponent<SpriteRenderer>();
            spr.sprite = cardSprite;
            card.Move(_cardPosition[posIndex], 1f, 1f, ease);

            _movingCards.Add(posIndex, card);

            _cardIndex++;
            posIndex++;
        }
    }

    public void SetCard()
    {
        foreach (var card in _movingCards)
        {
            card.Value.StopDOTween();
            Destroy(card.Value.gameObject);
        }
        _movingCards.Clear();
        _cardIndex = 0;
        posIndex = 0;
    }
}