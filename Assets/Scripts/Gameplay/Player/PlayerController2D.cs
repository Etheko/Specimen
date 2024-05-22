using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool movementEnabled = true;

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

    public VectorValue startingPosition;

    public bool hasSpawnPoint;

    public bool resetSpawnPoint;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        runningSpeed = speed * 2;
        originalSpeed = speed;
    }

    private void Start()
    {
        RoundUpAllCoordinates();
        CheckCollisions();

        if (resetSpawnPoint)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 0);
        }

        if (hasSpawnPoint)
        {
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) == 0)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
                Debug.Log("First time here");
            }
            else
            {
                Debug.Log("Not the first time here");
                transform.position = startingPosition.initialValue;
                animator.SetFloat("moveX", startingPosition.playerDirection.x);
                animator.SetFloat("moveY", startingPosition.playerDirection.y);
            }
        }
        else
        {
            transform.position = startingPosition.initialValue;
            animator.SetFloat("moveX", startingPosition.playerDirection.x);
            animator.SetFloat("moveY", startingPosition.playerDirection.y);
        }
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
        if (movementEnabled)
        {
            GetInput();
        }
        else
        {
            //stop animation after player has stopped moving
            if (animator.GetBool("isWalking"))
            {
                // wait half a second before stopping the animation
                StartCoroutine(StopAnimation());
            }
        }

    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isWalking", false);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
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

    private void CheckCollisions()
    {
        Collider2D collider;

        collider = Physics2D.OverlapBox(new Vector2(transform.position.x + upXOffset, transform.position.y + upYOffset), new Vector2(0, 0), 0);
        collisions[0] = (collider != null && collider.tag != "No Collider") ? 1 : 0;

        collider = Physics2D.OverlapBox(new Vector2(transform.position.x + downXOffset, transform.position.y + downYOffset), new Vector2(0, 0), 0);
        collisions[1] = (collider != null && collider.tag != "No Collider") ? 1 : 0;

        collider = Physics2D.OverlapBox(new Vector2(transform.position.x + leftXOffset, transform.position.y + leftYOffset), new Vector2(0, 0), 0);
        collisions[2] = (collider != null && collider.tag != "No Collider") ? 1 : 0;

        collider = Physics2D.OverlapBox(new Vector2(transform.position.x + rightXOffset, transform.position.y + rightYOffset), new Vector2(0, 0), 0);
        collisions[3] = (collider != null && collider.tag != "No Collider") ? 1 : 0;

        Debug.Log("UP: " + collisions[0] + " DOWN: " + collisions[1] + " LEFT: " + collisions[2] + " RIGHT: " + collisions[3]);
    }

}
