using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating_plankton : MonoBehaviour
{
    private float flee_speed;
    private float flee_distance;
    private GameObject player;
    private Eating_plankton_info info;
    private int met_wall = 0;
    void Start()
    {
        info = GameObject.FindObjectOfType<Eating_plankton_info>();
        flee_speed = info.flee_speed;
        flee_distance = info.flee_distance;
        player = info.player;
    }
    void Update()
    {
        ChangeDegree(player.gameObject.transform.position, transform.position);
        if ((transform.position - player.transform.position).magnitude <= flee_distance && met_wall == 0)
        {
            Flee(player);
        }
    }
    void Flee(GameObject o)
    {
        Vector3 direction = (transform.position - o.transform.position).normalized;
        if (direction.x > info.XMax) direction.x = info.XMax;
        else if (direction.x < info.Xmin) direction.x = info.Xmin;
        if (direction.y > info.YMax) direction.y = info.YMax;
        else if (direction.y < info.Ymin) direction.y = info.Ymin;

        if (direction.x > info.XMax) direction.x = info.XMax;
        else if (direction.x < info.Xmin) direction.x = info.Xmin;
        if (direction.y > info.YMax) direction.y = info.YMax;
        else if (direction.y < info.Ymin) direction.y = info.Ymin;

        transform.position += direction * flee_speed * Time.deltaTime;
        ChangeDegree(o.gameObject.transform.position, transform.position);
    }
    void ChangeDegree(Vector3 from, Vector3 to)
    {
        Vector3 change_angle = new Vector3(0, 0, Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI);
        Quaternion quaternion = Quaternion.identity;

        if (change_angle.z < -90 || change_angle.z > 90)
        {
            change_angle.x = 180;
            change_angle.z *= -1;
        }
        quaternion.eulerAngles = change_angle;
        transform.rotation = quaternion;
    }
}
