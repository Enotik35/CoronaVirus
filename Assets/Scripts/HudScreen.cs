using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Gun gun;
    public Text Text;
    public Player Player;
    public int full_bullets = 5;
    public int player_bullets;
    public int player_hp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player_hp = Player.HP;
        player_bullets = Player.Eat;
        Text.text = "HP:" + player_hp + "///" +"Bullets:" + player_bullets;
        if (player_bullets > full_bullets)
        {
            player_bullets = 0;
            full_bullets = full_bullets * 2;
        }
    }
}
