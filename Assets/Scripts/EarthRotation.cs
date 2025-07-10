using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthRotation : MonoBehaviour
{
    public float rotationSpeed = 0.001f; // Reduced rotation speed
    private Vector2 previousPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousPosition = touch.position;
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "India")
                    {
                        SceneManager.LoadScene("TajMahalScene");
                    }
                    else if (hit.collider.gameObject.tag == "Petra")
                    {
                        SceneManager.LoadScene("PetraScene");
                    }
                    else if (hit.collider.gameObject.tag == "Great")
                    {
                        SceneManager.LoadScene("GreatScene");
                    }
                    else if (hit.collider.gameObject.tag == "Chichen")
                    {
                        SceneManager.LoadScene("ChichenScene");
                    }
                    else if (hit.collider.gameObject.tag == "Pacchu")
                    {
                        SceneManager.LoadScene("PacchuScene");
                    }
                    else if (hit.collider.gameObject.tag == "Christ")
                    {
                        SceneManager.LoadScene("ChristScene");
                    }
                    else if (hit.collider.gameObject.tag == "Colo")
                    {
                        SceneManager.LoadScene("ColoScene");
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 direction = touch.position - previousPosition;
                previousPosition = touch.position;

                float rotationAroundY = -direction.x * rotationSpeed; // Horizontal rotation

                transform.Rotate(Vector3.up, rotationAroundY, Space.World);
            }
        }
    }
}
