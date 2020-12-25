using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_info : MonoBehaviour
{
    public int plankton;
    public float move_speed;
    public float attack_speed;
    public float damage;
    public float armor;
    public int eating_point;
    public void Stats_update(int cant, string stats)
    {
        switch (stats)
        {
            case "damage": damage += cant; break;
            case "plankton": plankton += cant; break;
            case "attack_speed": attack_speed += cant; break;
            case "move_speed": move_speed += cant; break;
            case "armor": armor += cant; break;
            case "eating_point": armor += cant; break;
            default: break;
        }
    }
}
