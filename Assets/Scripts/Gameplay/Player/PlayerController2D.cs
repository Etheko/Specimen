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

    public Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isWalking", isMoving);
    }

    private void Start()
    {
        runningSpeed = speed * 2;
        originalSpeed = speed;
    }

    private void Update()
    {
        GetInput();
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
