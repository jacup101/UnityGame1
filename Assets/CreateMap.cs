using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateMap : MonoBehaviour
{

    private readonly int numArg = 6;
    private string colorRule;
    // Start is called before the first frame update
    void Start()
    {


        System.Random rand = new System.Random();
        TextReader tr = new TextReader("LevelHard");
        string[] chunkTypes = tr.read();
        string[] newChunkTypes = new string[chunkTypes.Length - numArg];

        //Handle Numerical Args
        string distanceVal = chunkTypes[1];
        distanceVal = distanceVal.Substring(13);
        int distVal = Convert.ToInt32(distanceVal);
        Debug.Log(distVal);

        string length = chunkTypes[2];
        length = length.Substring(13);
        int len = Convert.ToInt32(length);
        Debug.Log(len);
        //Handle Game Rules
        colorRule = chunkTypes[3];
        //Handle Bool Args
        bool[] boolArgs = new bool[] { handleStringBool(chunkTypes[4]), handleStringBool(chunkTypes[5]) };
        //Handle Chunk Type Args
        for (int i=numArg;i<chunkTypes.Length;i++)
        {
            newChunkTypes[i - numArg] = chunkTypes[i];
            Debug.Log("WE HAVE GRABBED THIS CHUNKTYPE " + chunkTypes[i]);
        }
        int chunkAmount = 50;
        string previousType = "empty";
        for (int i=0;i<50;i++)
        {
            Chunk c = new Chunk(rand, previousType,chunkTypes[0], newChunkTypes,distVal,len);
            instantiateObject(c.getSize(), c.getPos(), c.getName(),false,"null");
            
            List<Colliders> colliders = c.getColliders();
            foreach (Colliders coll in colliders)
            {
                instantiateObject(coll.getSize(), coll.getPos(), coll.getName(),true,coll.getTrait());
            }
            previousType = c.getType(); 

        }
        Chunk finisher = new Chunk("finish", distVal, len);
        instantiateObject(finisher.getSize(), finisher.getPos(), finisher.getName(), false, "null");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void instantiateObject(float[] size, float[] pos, string name, bool color, string trait)
    {
        GameObject chunkBase;
        chunkBase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        chunkBase.transform.localScale = createVector3(size);
        chunkBase.transform.position = createVector3(pos);
        chunkBase.name = name;
        chunkBase.AddComponent<Rigidbody>();
        chunkBase.GetComponent<Rigidbody>().isKinematic = true;
        if (color) chunkBase.GetComponent<Renderer>().material.color = Color.black;
        if (trait == "Moving Collider")
        {

            chunkBase.AddComponent<MoveCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if(colorRule=="colors") chunkBase.GetComponent<Renderer>().material.color = Color.red;
        }
        if (trait == "Opaque Collider")
        {

            chunkBase.AddComponent<OpaqueCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if (colorRule == "colors")  chunkBase.GetComponent<Renderer>().material.color = Color.blue;
        } if(trait == "Teleporting Collider")
        {
            chunkBase.AddComponent<TeleportCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if (colorRule == "colors")  chunkBase.GetComponent<Renderer>().material.color = Color.magenta;
        }
        if(trait == "Individual Vertical Collider")
        {
            chunkBase.AddComponent<IVerticalCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if (colorRule == "colors") chunkBase.GetComponent<Renderer>().material.color = Color.green;
        }
        if (trait == "Individual Forward Collider")
        {
            chunkBase.AddComponent<IForwardCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if (colorRule == "colors") chunkBase.GetComponent<Renderer>().material.color = Color.black;
        }
        if (trait == "Simultaneous Vertical Collider")
        {
            chunkBase.AddComponent<SVerticalCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if (colorRule == "colors") chunkBase.GetComponent<Renderer>().material.color = Color.gray;
        }if (trait == "Forward Vertical Collider")
        {
            chunkBase.AddComponent<FIVerticalCollider>();
            //chunkBase.GetComponent<Rigidbody>().isKinematic = false;
            if (colorRule == "colors") chunkBase.GetComponent<Renderer>().material.color = Color.gray;
        }
        if (trait == "Horizontal Diagonal Collider")
        {
            chunkBase.AddComponent<HDiagonalCollider>();
            if (colorRule == "colors") chunkBase.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (trait == "Jumper")
        {
            chunkBase.GetComponent<Renderer>().material.color = Color.white;
            chunkBase.transform.eulerAngles = new Vector3(0,0,45);
        } if(trait == "Speeder")
        {
            chunkBase.GetComponent<Renderer>().material.color = Color.yellow;
        } if (trait == "AntiGrav")
        {
            chunkBase.GetComponent<Renderer>().material.color = Color.green;
        }if (trait == "Invulnerable")
        {
            chunkBase.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    Vector3 createVector3(float[] f)
    {
        if (f.Length != 3) throw new System.Exception("IncorrectSize");
        return new Vector3(f[0], f[1], f[2]);
    }
    bool handleStringBool(string toTest)
    {
        if (toTest.IndexOf("True") >= 0) return true;
        return false;
    }
}
