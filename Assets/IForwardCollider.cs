using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IForwardCollider : MonoBehaviour
{
    float center;
    float frontLim;
    float backLim;
    int distAllowed;
    float delta;
    int delay;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position[0];
        distAllowed = Random.Range(2, 8);
        frontLim = center - distAllowed;
        backLim = center + distAllowed;

        speed = Random.Range(.05f, .11f);
        delta = speed;
        int chance = Random.Range(0, 2);
        if (chance == 1) delta = -1 * speed;
        delay = Random.Range(1, 21);
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0)
        {
            if (transform.position[0] >= backLim)
            {
                delta = -1 * speed; ;

            }
            else if (transform.position[0] <= frontLim)
            {
                delta = speed;

            }
            transform.position = transform.position + new Vector3(delta, 0, 0);
        }
        else delay--;
    }
}
