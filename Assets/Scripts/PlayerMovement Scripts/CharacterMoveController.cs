using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveController : MonoBehaviour
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

    }

    void Update()
    {
        walkAnimator.SetFloat("Speed", movement.sqrMagnitude);
        walkAnimator.SetFloat("Horizontal", movement.x);
        walkAnimator.SetFloat("Vertical", movement.y);
            if(movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
            {
                walkAnimator.SetFloat("LastX", movement.x);
                walkAnimator.SetFloat("LastY", movement.y);
            }
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       // rb.MovePosition(this.transform.position);
       rb.MovePosition(new Vector2((transform.position.x + speed * movement.x * Time.deltaTime),(transform.position.y + speed * movement.y * Time.deltaTime)));
    }
}
