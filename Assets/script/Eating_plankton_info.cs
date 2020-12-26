using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating_plankton_info : MonoBehaviour
{
    public float flee_speed;
    public float flee_distance;
    public GameObject player;
    private Summoner summoner;
    public float XMax, Xmin, YMax, Ymin;

    private void Start()
    {
        summoner = GameObject.FindObjectOfType<Summoner>();
        RectTransform Map = summoner.Map;
        float inter_summon_size = summoner.inter_summon_size;
        Vector2 set_pos = Vector2.zero;
        set_pos.x = Map.gameObject.transform.position.x; set_pos.y = Map.gameObject.transform.position.y;

        XMax = Map.sizeDelta.x / 2 - inter_summon_size; Xmin = -Map.sizeDelta.x / 2 + inter_summon_size;
        YMax = Map.sizeDelta.y / 2 - inter_summon_size; Ymin = -Map.sizeDelta.y / 2 + inter_summon_size;
    }
}
