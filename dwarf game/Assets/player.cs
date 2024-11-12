using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    static int nextScene = 0;
    int score;
    float Speed = 5;
    Rigidbody2D rb;
    Vector3 startPosition;
    public TMP_Text ScoreText;
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);
        direction *= Speed;
        rb.velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Rammer en fjende");
            transform.position = startPosition;
        }
        if (collision.collider.CompareTag("Collectable"))
        {
            score = score + 1;
            Debug.Log("Du samler en stjerne op!");
            Debug.Log("Din score er nu " + score);
            ScoreText.text = "Score: " + score;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Win"))
        {
            Debug.Log("WIN");
            nextScene = nextScene + 1;
            SceneManager.LoadScene(nextScene);

        }

    }
}
