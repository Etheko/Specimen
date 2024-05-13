using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMenuCube : MonoBehaviour
{
    public float sensitivity = 100f; // Sensitivity of mouse movement

    void Update()
    {
        // Get the current position of the mouse
        Vector3 mousePos = Input.mousePosition;

        // Convert mouse position from screen space to world space
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        Plane plane = new Plane(Vector3.up, transform.position); // Assuming the plane is aligned with the Y-axis
        float distance;
        if (plane.Raycast(mouseRay, out distance))
        {
            Vector3 target = mouseRay.GetPoint(distance);

            // Calculate the direction from the cube to the mouse position
            Vector3 lookDir = target - transform.position;

            // Rotate the cube to look at the mouse position
            transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
        }
    }
}
