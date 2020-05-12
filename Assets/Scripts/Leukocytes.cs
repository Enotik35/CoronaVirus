using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leukocytes : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 20;
    public int speed;
    private int real_speed;
    Transform target;
    public float seeDistance;
    public float attackDistance;
    private float timeshoot;
    public float startTime;
    public GameObject LeukocyteBullet;
    public Transform ShootDir;

    private void Start()
    {
        real_speed = speed;
        target = GameObject.FindWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
            {
                //walk
                transform.right = target.position - transform.position;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                if (timeshoot <= 0)
                {
                    Instantiate(LeukocyteBullet, ShootDir.position, transform.rotation);
                    timeshoot = startTime;
                }
                else
                {
                    timeshoot -= Time.deltaTime;
                }
            }
        }
        else
        {
            //idle
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            HP -= 10;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
