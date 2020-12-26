using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_activity : MonoBehaviour
{
    private Player_info player_info;
    private Summoner summoner;
    void Start()
    {
        player_info = GameObject.FindObjectOfType<Player_info>();
        summoner = GameObject.FindObjectOfType<Summoner>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D o)
    {
        if (o.gameObject.CompareTag("eating_plankton"))
        {
            Eat();
            Destroy(o.gameObject);
        }
    }
    void Eat()
    {
        player_info.Stats_update(player_info.eating_point, "plankton");
        summoner.Destory_plankton();
    }
}
