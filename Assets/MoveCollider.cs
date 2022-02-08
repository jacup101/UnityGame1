using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider : MonoBehaviour
{
    float speed;
    float delta;
    // Start is called before the first frame update
    void Start()
    {
        
        speed = Random.Range(.05f,.11f);
        if (transform.position[2] >= 0f) delta = -1 * speed;
        else delta = speed; 
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position[2] >= 2f)
        {
            delta = -1*speed; ;
            
        }
        else if (transform.position[2] <= -2f)
        {
            delta = speed ;

        }   //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, currSpeed);
            transform.position = transform.position + new Vector3(0,0,delta);
        
        
    }
}
