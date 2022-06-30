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
        rb.MovePosition(moveTo(player));
    }
    private Vector2 moveTo(GameObject player)
    {
        movement.x = getX(player);
        movement.y = getY(player);

        return new Vector2((transform.position.x + speed * movement.x * Time.deltaTime), (transform.position.y + speed * movement.y * Time.deltaTime));
    }
    private float getX(GameObject player)
    {
        return player.transform.position.x - transform.position.x;
    }
    private float getY(GameObject player)
    {
        return player.transform.position.y - transform.position.y;
    }

}
