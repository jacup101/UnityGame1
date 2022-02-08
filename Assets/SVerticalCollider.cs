using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVerticalCollider : MonoBehaviour
{

    float timer = 0;
    float deltaA = .1f;
    // Start is called before the first frame update
    void Start()
    {
        deltaA = -1 * deltaA;
    }

    // Update is called once per frame
    void Update()
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
    transform.position = new Vector3(transform.position[0], transform.position[1] + deltaA, transform.position[2]);
    }
}
