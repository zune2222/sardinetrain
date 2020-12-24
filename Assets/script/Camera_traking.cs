using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_traking : MonoBehaviour
{
    public GameObject player;
    public float traking_speed;
    private Vector3 last_target_pos = Vector3.zero;
    private Vector3 current_target_pos = Vector3.zero;
    private float current_lerp_dis = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 player_pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        Vector3 camera_pos = transform.position;
        Vector3 start_pos = player_pos;

        last_target_pos = start_pos;
        current_target_pos = start_pos;
        current_lerp_dis = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTraking();

        current_lerp_dis += traking_speed;
        transform.position = Vector3.Lerp(last_target_pos, current_target_pos, current_lerp_dis);
    }

    private void PlayerTraking()
    {
        Vector3 current_cam_pos = transform.position;
        Vector3 current_payer_pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (current_cam_pos.x == current_payer_pos.x && current_cam_pos.y == current_payer_pos.y)
        {
            current_lerp_dis = 1f;
            last_target_pos = current_cam_pos;
            current_target_pos = current_cam_pos;
        }
        else
        {
            current_lerp_dis = 0f;
            last_target_pos = current_cam_pos;
            current_target_pos = current_payer_pos;
        }
    }
}
