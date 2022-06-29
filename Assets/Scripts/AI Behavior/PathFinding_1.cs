using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding_1 : MonoBehaviour
{
    private Rigidbody2D rb; //main rigidbody
                            //    public Animator walkAnimator; //animator for implementing walk animations
    public Animator walkAnimator;
    private Vector2 movement;
    public float moveSpeed;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 1;
    }
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        movement.x = player.transform.position.x - transform.position.x;
        movement.y = player.transform.position.y - transform.position.y;
        // rb.MovePosition(this.transform.position);
        rb.MovePosition(new Vector2((transform.position.x + speed * movement.x * Time.deltaTime), (transform.position.y + speed * movement.y * Time.deltaTime)));
    }
}
