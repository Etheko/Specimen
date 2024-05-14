using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private bool isMoving;

    private Vector2 input;


    private void GetInput()
    {
        if (!isMoving)
        {
            input = Vector2.zero;

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                input.y = 1;
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                input.y = -1;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                // change sprite image
                input.x = 1;
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                input.x = -1;

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
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
}