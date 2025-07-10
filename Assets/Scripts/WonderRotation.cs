using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderRotation : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    private Vector2 previousPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 direction = touch.position - previousPosition;
                previousPosition = touch.position;

                float rotationAroundY = -direction.x * rotationSpeed; // Horizontal rotation

                transform.Rotate(Vector3.up, rotationAroundY, Space.Self); // Rotate around local y-axis
            }
        }
    }
}
