using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float _lifeTime = 3.0f;
    private GameManager _manager;

    private void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime < 0) 
            Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            //whatDidIHit.GetComponent<Player>().AddScore();
            _manager.EarnScore(1);
            Destroy(this.gameObject);
        } 
    }
}
