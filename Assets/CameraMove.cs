using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float horizontalSpeed = 2f;
    float verticalSpeed = 2f;
    float[] vectorPos = new float[] { -8f, 3f, 0 };
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 orig = player.transform.position;
        Vector3 curr = orig + new Vector3(vectorPos[0], vectorPos[1], vectorPos[2]);
        transform.position = curr;
        //transform.position = transform.position + new Vector3(10, 0, 0);
        //rotation

        if (Input.GetMouseButton(1))
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float x = horizontalSpeed * Input.GetAxis("Mouse ScrollWheel");

            transform.RotateAround(player.transform.localPosition, transform.up, 1f*h);
            vectorPos[0] = transform.position[0] - player.transform.position[0]; vectorPos[2] = transform.position[2] - player.transform.position[2];
            
            //float v = verticalSpeed * Input.GetAxis("Mouse Y");

            //tank.transform.Rotate(h,tank.transform.up);
            if(x!=0)
            {
                vectorPos[0] = vectorPos[0] / x;
                vectorPos[1] = vectorPos[1] / x;
                vectorPos[2] = vectorPos[2] / x;
            }
            



            //transform.RotateAround(tank.localPosition, tank.up, 1f*h);

            //tank2.transform.Rotate(0, -1 * h, 0);

            //transform.LookAt(tank2.transform);

        }
        transform.LookAt(player.transform);


        //stick to player

    }
}
