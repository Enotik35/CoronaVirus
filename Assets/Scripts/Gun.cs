using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform ShootDir;
    public HudScreen hs;
    private float timeshoot;
    public float startTime;
    public int ammo;
    private void Start()
    {
        
    }

    private void Update()
    {
        ammo = hs.player_bullets;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (timeshoot <= 0)
        {
            if (ammo > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hs.Player.Shoot();
                    Instantiate(bullet, ShootDir.position, transform.rotation);
                    timeshoot = startTime;
                }
            }
        }
        else
        {
            timeshoot -= Time.deltaTime;
        }
    }
}