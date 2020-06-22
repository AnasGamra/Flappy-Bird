using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MoveFaby : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float JumpForce = 10f;
    public float speed = 5f;
    bool isDead;
    public GameObject replayButton, playButton;

    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed;
        replayButton.SetActive(false);
        playButton.SetActive(true);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        replayButton.SetActive(true);
        GetComponent<Animator>().SetBool("isDead", true);

    }
    public void UnFreeze()
    {
        Time.timeScale = 1;
        playButton.SetActive(false);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb2d.velocity = Vector2.right * speed;
            rb2d.AddForce(Vector2.up * JumpForce);

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Score")
        {
            score++;
            Debug.Log(score);
            scoreText.text = score.ToString();
        }

    }
}    
