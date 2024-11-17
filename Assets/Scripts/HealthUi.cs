using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    private TMP_Text _hpText;
    private Player _player;

    private void Start()
    {
        _hpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_player == null)
        {
            _player = GameObject.Find("Player(Clone)").GetComponent<Player>();
        }
        _hpText.text = "Health: " + _player.lives;
    }
}
