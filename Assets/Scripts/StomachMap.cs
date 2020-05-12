using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachMap : MonoBehaviour
{
    public Animation anim;
    public int ancid_time;
    public Player player;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Проверка стоит ли Игрок внутри Зоны
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (delay <= 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                // УРОН
                player.HP -= 20;
                player.Health();
            }
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }

    // При первом столкновении
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.HP -= 20;
            player.Health();
        }
    }
}
