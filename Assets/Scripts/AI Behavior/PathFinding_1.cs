using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding_1 : MonoBehaviour
{
    public Animator walkAnimator;
    private Rigidbody2D rb; //main rigidbody
    private Vector2 movement;
    public float moveSpeed;
    public int speed;
    private int defaultSpeed;
    public GameObject player;
    public bool canChase;
    public float test;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = speed;
        speed = 2;
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        test = Vector2.Distance(transform.position, player.transform.position);
        walkAnimator.SetFloat("Speed", speed);
        walkAnimator.SetFloat("Horizontal", movement.x);
        walkAnimator.SetFloat("Vertical", movement.y);
        // if(Math.Abs(getX(player)) < 1f || Math.Abs(getY(player)) < 1f || Math.Abs(getX(player)) > 4f || Math.Abs(getY(player)) > 4f)
        if(movement.x >= 0 || movement.x <= -1 || movement.y >= 1 || movement.y <= -1)
        {
            walkAnimator.SetFloat("LastX", movement.x);
            walkAnimator.SetFloat("LastY", movement.y);
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(moveTo(player));
    }
    private Vector2 moveTo(GameObject player)
    {
        Vector2 entityMovement = new Vector2((transform.position.x),(transform.position.y));

        movement.x = getX(player);
        movement.y = getY(player);
        movement = movement.normalized;
        speed = 0;
        if(Vector2.Distance(transform.position, player.transform.position) < 1 || Vector2.Distance(transform.position, player.transform.position) > 6)
        {
            speed = 0;
            entityMovement = new Vector2((transform.position.x),(transform.position.y));

        }
        else if (Vector2.Distance(transform.position, player.transform.position) > 2)
        {
            speed = 2;
            entityMovement = new Vector2((transform.position.x + speed * movement.x * Time.deltaTime), (transform.position.y + speed * movement.y * Time.deltaTime));     
        }
        

        return entityMovement;

    }
    private float getX(GameObject player)
    {
        if(player != null)
        {
            return player.transform.position.x - transform.position.x;
        }
        else
        {
            return transform.position.x;
        }
    }
    private float getY(GameObject player)
    {
        if(player != null)
        {
            return player.transform.position.y - transform.position.y;
        }
        else
        {
            return transform.position.y;
        }
    }

}
