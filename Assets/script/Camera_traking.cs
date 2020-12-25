using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_traking : MonoBehaviour
{
    private Player_info player_info;
    public GameObject player;
    public RectTransform game_screen;
    public float traking_speed;
    private float XMax, Xmin;
    private float YMax, Ymin;
    public float camara_x, camara_y;
    private Vector3 last_target_pos = Vector3.zero;
    private Vector3 current_target_pos = Vector3.zero;
    private float current_lerp_dis = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 player_pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        Vector3 camera_pos = transform.position;
        Vector3 start_pos = player_pos;

        player_info = GameObject.FindObjectOfType<Player_info>();
        traking_speed *= player_info.move_speed;
        last_target_pos = start_pos;
        current_target_pos = start_pos;
        current_lerp_dis = 1.0f;
        XMax = game_screen.sizeDelta.x / 2 - camara_x / 2; Xmin = -XMax;
        YMax = game_screen.sizeDelta.y / 2 - camara_y / 2; Ymin = -YMax;
        XMax += game_screen.gameObject.transform.position.x;
        Xmin += game_screen.gameObject.transform.position.x;
        YMax += game_screen.gameObject.transform.position.y;
        Ymin += game_screen.gameObject.transform.position.y;
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
        if (current_payer_pos.x > XMax) current_payer_pos.x = XMax;
        else if (current_payer_pos.x < Xmin) current_payer_pos.x = Xmin;
        if (current_payer_pos.y > YMax) current_payer_pos.y = YMax;
        else if (current_payer_pos.y < Ymin) current_payer_pos.y = Ymin;

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
