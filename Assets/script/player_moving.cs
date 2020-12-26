using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moving : MonoBehaviour
{
    private float speed;
    private Joystick joystick;
    private Player_info player_info;

    Rigidbody2D rigid;
    Animator animator;

    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
        player_info = GameObject.FindObjectOfType<Player_info>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
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
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        Vector3 change_angle = joystick.angle;
        transform.position += upMovement;
        transform.position += rightMovement;
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
