using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float horizontalScreenLimit;
    private float verticalScreenLimit;

    public GameObject explosion;
    public GameObject bullet;
    private int lives;


    private int score = 0;
    public TMP_Text _liveText;
    public TMP_Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        horizontalScreenLimit = 11.5f;
        verticalScreenLimit = 7.5f;
        lives = 3;
        score = 0;
        _liveText = GameObject.Find("Lives").GetComponent<TMP_Text>();
        _scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();

        UpdateLiveText(lives);
        UpdateScoreText(score);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    private void UpdateLiveText(int count)
    {
        if (_liveText == null) return;
        _liveText.text = "Lives: " + count;
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseALife()
    {
        //lives = lives - 1;
        //lives -= 1;
        lives--;
        UpdateLiveText(lives);

        if (lives == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void AddScore()
    {
        if (_scoreText == null) return;

        score++;
        UpdateScoreText(score);
    }

    private void UpdateScoreText(int newScore)
    {
        _scoreText.text = "Score: " + newScore;
    }
}
