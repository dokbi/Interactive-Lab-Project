using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public float speed;
    public GameObject ScoreManager;
    public int playerID;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //what causes the player object to move
        Vector2 force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddForce(force * speed);
        
        //allows the player to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 8f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    //will allow the player to collect coins
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            ScoreManager.SendMessage("collect",playerID);
        }  
    }

    // identifies collision in the console
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            Debug.LogFormat("Collision!");
        }
        else if (collision.gameObject.name == "Enemy")
        {
            Debug.LogFormat("Ouch!");
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}