using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public int level;
    public int plankton_cant;
    public int Max_plankton_cant;
    public float plankton_summon_time;
    public float inter_summon_size;
    public float unsummon_size;
    private Vector2 set_pos;
    public GameObject Plankton_prefeb;
    private GameObject game_screen;
    public GameObject parent;
    public GameObject player;
    public RectTransform Map;
    void Start()
    {
        InvokeRepeating("Summon_Plankton", 0f, plankton_summon_time);
        game_screen = Map.gameObject;
        set_pos.x = game_screen.transform.position.x;
        set_pos.y = game_screen.transform.position.y;
    }
    void Update()
    {

    }
    void Summon_Plankton()
    {
        float unsummon_mx = player.transform.position.x - unsummon_size / 2, unsummon_Mx = player.transform.position.x + unsummon_size / 2;
        float unsummon_my = player.transform.position.y - unsummon_size / 2, unsummon_My = player.transform.position.y + unsummon_size / 2;
        float XMax = Map.sizeDelta.x / 2 - inter_summon_size + set_pos.x, Xmin = -Map.sizeDelta.x / 2 + inter_summon_size + set_pos.x;
        float YMax = Map.sizeDelta.y / 2 - inter_summon_size + set_pos.y, Ymin = -Map.sizeDelta.y / 2 + inter_summon_size + set_pos.y;

        if (unsummon_Mx > XMax) unsummon_Mx = XMax;
        if (unsummon_mx < Xmin) unsummon_mx = Xmin;
        if (unsummon_My > YMax) unsummon_My = YMax;
        if (unsummon_my < Ymin) unsummon_my = Ymin;

        float randomX = Random.Range(Xmin, XMax);
        float randomY = Random.Range(Ymin, YMax);

        if (randomX < unsummon_Mx && randomX > unsummon_mx && randomY < unsummon_My && randomY > unsummon_my)
        {
            if (unsummon_Mx == XMax || XMax - randomX < randomX - Xmin) randomX = unsummon_mx;
            else randomX = unsummon_Mx;
            if (unsummon_My == YMax || YMax - randomY < randomY - Ymin) randomY = unsummon_my;
            else randomY = unsummon_My;
        }

        if (plankton_cant<Max_plankton_cant && randomX<=XMax && randomX>=Xmin && randomY<=YMax && randomY>=Ymin)
        {
            GameObject.Instantiate(Plankton_prefeb, new Vector3(randomX, randomY, -10f), Quaternion.identity).transform.parent = parent.transform;
            plankton_cant++;
        }
    }
    public void Destory_plankton() { plankton_cant--; }
}
