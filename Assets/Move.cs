using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    bool invulnerable = false;
    int invulnerableTime = 0;
    float speed = 20f;
    bool isDead = false;
    int jumpTimer = 0;
    int distance = 50;
    float[] jumpSpeeds = new float[] { .1f, .2f, .3f, .4f, .5f };
    int angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;

    }

    // Update is called once per frame
    void Update()
    {
        var component = GetComponent<Rigidbody>();
        bool[] mvmts = receiveInputs();
        Vector3 oldVelocity = component.velocity;
        float grav = oldVelocity[1] - 1;
        float forwardVelocity = speed;
        if (mvmts[5]) forwardVelocity = 0;
        component.velocity = new Vector3(forwardVelocity,grav,0);
            
        if (mvmts[1]) component.velocity = component.velocity + new Vector3(0, 0, 10);
        if (mvmts[3]) component.velocity = component.velocity - new Vector3(0, 0, 10);
        if (mvmts[4] && grav == -1) component.velocity = component.velocity + new Vector3(0,20f, 0);
        if (transform.position[2] >= 2f && component.velocity[2]==10) component.velocity = component.velocity + new Vector3(0, 0, -10);
        if (transform.position[2] <= -2f && component.velocity[2]==-10) component.velocity = component.velocity + new Vector3(0, 0, 10);

        if (speed > 20f) speed = speed - .2f;

        //Invulnerability Handlers
        if(invulnerable)
        {
            invulnerableTime--;
            if (invulnerableTime == 0) invulnerable = false;
        }
        /*double ang = Math.PI * angle / 180;
        float test = (float) Math.Abs(Math.Sin(ang));
        Debug.Log("" + angle + "  " + ang);
        if (angle == 359) angle = 0;
        else angle++;
        component.velocity = new Vector3(component.velocity[0] * test, component.velocity[1], component.velocity[2]);*/

    }
    bool[] receiveInputs()
    {
        return new bool[] {Input.GetKey("w"),Input.GetKey("a"),Input.GetKey("s"),Input.GetKey("d"),Input.GetKey("space"),Input.GetKey(KeyCode.LeftShift)};
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.transform.name.IndexOf("Collider") >= 0 && !invulnerable)
        {
            //speed = speed * -1;
            isDead = true;
            GameObject hello = GameObject.Find("Player");
            Destroy(hello);
        }
        if (col.gameObject.transform.name.IndexOf("Speeder") >= 0) speed = speed + 20;
        if (col.gameObject.transform.name.IndexOf("Jumper") >= 0) speed = speed + 10;
        if (col.gameObject.transform.name.IndexOf("Invulnerable") >= 0)
        {
            invulnerable = true;
            invulnerableTime = 200;
        }
        if (col.gameObject.transform.name.IndexOf("AntiGrav") >= 0) GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0, 50f, 0);
    }
    
    
    
}
