using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float Speed;
    public int Eat;
    public HudScreen hs;
    public int HP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal_move = Input.GetAxis("Horizontal");
        float vertical_move = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal_move * Speed, vertical_move * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Eat")
        {
            Destroy(collision.gameObject);
            Eat += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            HP -= 10;
            Health();
        }
    }

    public void Health()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Shoot()
    {
        Eat -= 1;
    }
}
