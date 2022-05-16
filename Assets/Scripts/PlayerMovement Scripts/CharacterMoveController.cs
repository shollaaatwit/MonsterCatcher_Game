using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveController : MonoBehaviour
{

    private Rigidbody2D rb; //main rigidbody
//    public Animator walkAnimator; //animator for implementing walk animations
    private Vector2 movement;
    public int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       // rb.MovePosition(this.transform.position);
        rb.MovePosition(new Vector2((transform.position.x + movement.x * speed * Time.deltaTime),(transform.position.y + movement.y * speed * Time.deltaTime)));
    }
}
