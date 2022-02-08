using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIVerticalCollider : MonoBehaviour
{


    float center;
    float frontLim;
    float backLim;
    int distAllowed;
    float xDelta;
    float xSpeed;

    float timer = 0;
    float deltaA = .1f;
    int delay;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position[0];
        distAllowed = Random.Range(2, 8);
        frontLim = center - distAllowed;
        backLim = center + distAllowed;

        xSpeed = Random.Range(.05f, .11f);
        xDelta = xSpeed;
        int chance = Random.Range(0, 2);
        if (chance == 1) xDelta = -1 * xSpeed;

        deltaA = Random.Range(.05f, .11f);
        deltaA = -1 * deltaA;
        delay = Random.Range(1, 21);
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0)
        {

            float posY = transform.position[1];



            if (posY <= 1.5f)
            {
                deltaA = -1 * deltaA;
            }
            if (posY >= 5.5f)
            {

                deltaA = -1 * deltaA;
            }
            if (transform.position[0] >= backLim)
            {
                xDelta = -1 * xSpeed; ;

            }
            else if (transform.position[0] <= frontLim)
            {
                xDelta = xSpeed;

            }
            transform.position = transform.position + new Vector3(xDelta, deltaA, 0);
        }
        else delay--;

    }
}
