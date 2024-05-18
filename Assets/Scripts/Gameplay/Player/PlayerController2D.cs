using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public LayerMask solidObjectsLayer;

    private float runningSpeed;

    private float originalSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    private Vector2 startPos;

    private bool hasCollided = false;

    public Rigidbody2D rb;

    private int[] collisions = new int[4]; // 0 = up, 1 = down, 2 = left, 3 = right

    public float upXOffset = 0;

    public float upYOffset = -0.5f;

    public float downXOffset = 0;

    public float downYOffset = -2;

    public float leftXOffset = -1;

    public float leftYOffset = -1.5f;

    public float rightXOffset = 1;

    public float rightYOffset = -1.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        runningSpeed = speed * 2;
        originalSpeed = speed;
    }


    private void GetInput()
    {
        if (!isMoving)
        {
            input = Vector2.zero;

            // Get the input from the player
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // if shift is pressed, double the speed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runningSpeed;
            }
            else
            {
                speed = originalSpeed;
            }

            if (input != Vector2.zero)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }

                startPos = transform.position;
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
        
                // if any of the adjacent cells have a collisionbox, stop the player from moving to that direction
                if (input.x == 1 && collisions[3] == 1)
                {
                    input.x = 0;
                }
                else if (input.x == -1 && collisions[2] == 1)
                {
                    input.x = 0;
                }
                else if (input.y == 1 && collisions[0] == 1)
                {
                    input.y = 0;
                }
                else if (input.y == -1 && collisions[1] == 1)
                {
                    input.y = 0;
                }

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isWalking", isMoving);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            hasCollided = true;
            //stop the player from moving
            StopAllCoroutines();
            speed = originalSpeed;
            hasCollided = false;
            StartCoroutine(Move(startPos));


        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            hasCollided = true;
            //stop the player from moving
            StopAllCoroutines();
            speed = originalSpeed;
            hasCollided = false;
            StartCoroutine(Move(startPos));

        }
    }

    private void Update()
    {
        GetInput();
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && !hasCollided)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        var xDiff = startPos.x - targetPos.x;
        var yDiff = startPos.y - targetPos.y;
        transform.position = targetPos;
        isMoving = false;
        CheckCollisions();
        RoundUpAllCoordinates(); // remove coordinates with decimals and round them up
    }

    private void RoundUpAllCoordinates()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
    }

    private void CheckCollisions() // Check if any of the adjacent cells have a collisionbox (the offset is due to the pivot point of the player)
    {
        collisions[0] = Physics2D.OverlapBox(new Vector2(transform.position.x + upXOffset, transform.position.y + upYOffset), new Vector2(0, 0), 0) ? 1 : 0;

        collisions[1] = Physics2D.OverlapBox(new Vector2(transform.position.x + downXOffset, transform.position.y + downYOffset), new Vector2(0, 0), 0) ? 1 : 0;

        collisions[2] = Physics2D.OverlapBox(new Vector2(transform.position.x + leftXOffset, transform.position.y + leftYOffset), new Vector2(0, 0), 0) ? 1 : 0;

        collisions[3] = Physics2D.OverlapBox(new Vector2(transform.position.x + rightXOffset, transform.position.y + rightYOffset), new Vector2(0, 0), 0) ? 1 : 0;

    }
}
