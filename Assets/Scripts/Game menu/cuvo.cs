using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuvo : MonoBehaviour, figura
{
    
    public float rotationSpeed = 50f;

    public void RotateShape(float rotationSpeed)
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

    }
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.RotateShape(rotationSpeed);
    }
}