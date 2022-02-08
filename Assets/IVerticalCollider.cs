using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IVerticalCollider : MonoBehaviour
{
    float timer = 0;
    float deltaA = .1f;
    int delay;
    // Start is called before the first frame update
    void Start()
    {
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
            if (posY >= 5.5f) { 
            
                deltaA = -1 * deltaA;
            }
            transform.position = new Vector3(transform.position[0], transform.position[1] + deltaA, transform.position[2]);
        }
        else delay--;
    }
}
