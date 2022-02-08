using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDiagonalCollider : MonoBehaviour
{


    float center;
    float frontLim;
    float backLim;
    int distAllowed;
    float xDelta;
    float xSpeed;

    float zSpeed;
    float zDelta;
    // Start is called before the first frame update
    void Start()
    {
        zSpeed = Random.Range(.05f, .11f);
        if (transform.position[2] >= 0f) zDelta = -1 * zSpeed;
        else zDelta = zSpeed;
        GetComponent<Rigidbody>().useGravity = false;

        center = transform.position[0];
        distAllowed = Random.Range(2, 8);
        frontLim = center - distAllowed;
        backLim = center + distAllowed;

        xSpeed = Random.Range(.05f, .11f);
        xDelta = xSpeed;
        int chance = Random.Range(0, 2);
        if (chance == 1) xDelta = -1 * xSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position[0] >= backLim)
        {
            xDelta = -1 * xSpeed; ;

        }
        else if (transform.position[0] <= frontLim)
        {
            xDelta = xSpeed;

        }
        if (transform.position[2] >= 2f)
        {
            zDelta = -1 * zSpeed; ;

        }
        else if (transform.position[2] <= -2f)
        {
            zDelta = zSpeed;

        }
        transform.position = transform.position + new Vector3(xDelta, 0, zDelta);
       
    }
}
