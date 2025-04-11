using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    int direction = 1;

    [SerializeField]
    private float right = 0.5f;
    [SerializeField]
    private float left = -0.5f;
    [SerializeField]
    private float speed = 1;





    // Update is called once per frame
    void  FixedUpdate()
    {


        if (direction < 0)
        {
            if (transform.position.x < right)
            {
                transform.position = new Vector3(transform.position.x + 0.01f * speed, transform.position.y, transform.position.z);
            }
            else
            {
                direction *= -1;
            }
        }

        else
        {
            if (transform.position.x > left)
            {
                transform.position = new Vector3(transform.position.x - 0.01f * speed, transform.position.y, transform.position.z);
            }
            else
            {
                direction *= -1;

            }
        }

    }

}