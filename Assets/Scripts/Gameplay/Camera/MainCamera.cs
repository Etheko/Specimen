using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FollowPlayer()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }


    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

    }
}
