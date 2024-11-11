using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject cloud;
    public GameObject coin;

    private int score;

    public TextMeshProUGUI scoreText;

    [SerializeField]
    private Vector3 coinBounds;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("SpawnCoin", 1f, 3f);

        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void SpawnCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-coinBounds.x/2, coinBounds.x/2) + transform.position.x, Random.Range(-coinBounds.y/2, coinBounds.y/2) + transform.position.y, 0), Quaternion.identity);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, coinBounds);
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int howMuch) 
    {  
        score = score + howMuch;
        scoreText.text = "Score: " + score;
    }

}
