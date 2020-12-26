using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_moving : MonoBehaviour
{
    private float speed;
    private Joystick joystick;
    private Player_info player_info;
    public RectTransform game_screen;
    public float size_x, size_y;

    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
        player_info = GameObject.FindObjectOfType<Player_info>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        speed = player_info.move_speed;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Move();
        }
    }
    void Move()
    {
        float vertical = joystick.Vertical, horizontal = joystick.Horizontal;
        if(Mathf.Abs(vertical)>Mathf.Abs(horizontal))
        {
            horizontal *= speed / Mathf.Abs(vertical);
            if (vertical < 0) vertical = -speed;
            else vertical = speed;
        }
        else
        {
            vertical *= speed / Mathf.Abs(horizontal);
            if (horizontal < 0) horizontal = -speed;
            else horizontal = speed;
        }
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * horizontal;
        Vector3 change_angle = joystick.angle;


        transform.position += upMovement; transform.position += rightMovement;
        
        Quaternion quaternion = Quaternion.identity;

        if (change_angle.z<-90 || change_angle.z>90)
        {
            change_angle.x = 180;
            change_angle.z *= -1;
        }
        quaternion.eulerAngles = change_angle;
        transform.rotation = quaternion;
    }
}
