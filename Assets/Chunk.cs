using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public static int ID = 0;
    public static float position = 0;
    private string name;
    private float[] chunkSize;
    private float[] chunkPos;
    private List<Colliders> colliders;
    private System.Random rand;
    private string chunkType;
    private Values val;
    private int distanceVal = 5;
    private int chunkLengthFinal = 20;
    private string[] chunkTypes = new string[] { "mixed", "hardmixed", "movemixed", "teleport","opaqueindividual","individual", "moving","vertical","simulvert","forward"
                                                ,"hordiag","fvertical"};
    private string mainType = "mixed";
    // Start is called before the first frame update


    public Chunk(System.Random random,string previousType, string main, string[] types,int dist, int cLength)
    {
        mainType = main;
        chunkTypes = types;
        chunkLengthFinal = cLength;
        distanceVal = dist;
        rand = random;
        val = new Values(rand);
        if (ID == 0) chunkType = "empty";
        else if(previousType != mainType)
        {
            chunkType = previousType;
            while(chunkType == previousType) chunkType = chunkTypes[rand.Next(0, chunkTypes.Length)];

        } else if( previousType == mainType)
        {
            chunkType = chunkTypes[rand.Next(0, chunkTypes.Length)];
        }
        //Debug.Log("CHUNKTYPEEEEEE " + chunkType);
        name = "Chunk " + ID + " " + chunkType;
        chunkSize = new float[] { chunkLengthFinal, 2, 5 };
        chunkPos = new float[] { position, 0, 0 };
        colliders = new List<Colliders>();
        createColliders();
        ID++; position += chunkLengthFinal;
        
    }
    public Chunk(string type, int dist, int cLength)
    {
        mainType = type;
        chunkType = type;
        chunkLengthFinal = cLength;
        distanceVal = dist;
        name = "Chunk " + ID + " " + chunkType;
        chunkSize = new float[] { chunkLengthFinal, 2, 5 };
        chunkPos = new float[] { position, 0, 0 };
        colliders = new List<Colliders>();
        ID++; position += chunkLengthFinal;
    }
    public float[] getSize() { return chunkSize; }
    public float[] getPos() { return chunkPos; }
    public string getName() { return name; }
    public List<Colliders> getColliders() { return colliders; }
    public string getType() { return chunkType; }
    void createColliders()
    {
        
        
        int currPos = (int)chunkPos[0];
        int chance = rand.Next(1, 3);
        while(currPos<(int)(chunkPos[0]) + chunkLengthFinal)
        {
            colliders = val.returnColliders(colliders, currPos, chunkType);
            currPos += distanceVal;
        }
        //Try Spawning Speeder
        chance = rand.Next(0, 4);
        if(chance==3)
        {
            chance = rand.Next(1, 6);
            int xPos = (int)chunkPos[0] + (chance * 3);
            int zPos = rand.Next(-2, 3);
            colliders.Add(new Colliders(xPos,1f,zPos,"Speeder",new float[] {1f,.01f,1f }));
        }
        //Try Spawning AntiGrav
        chance = rand.Next(0, 7);
        if (chance == 3)
        {
            chance = rand.Next(1, 6);
            int xPos = (int)chunkPos[0] + (chance * 3);
            int zPos = rand.Next(-2, 3);
            colliders.Add(new Colliders(xPos, 1f, zPos, "AntiGrav", new float[] { 1f, .01f, 1f }));
        }
        chance = rand.Next(0, 7);
        if (chance == 3)
        {
            chance = rand.Next(1, 6);
            int xPos = (int)chunkPos[0] + (chance * 3);
            int zPos = rand.Next(-2, 3);
            colliders.Add(new Colliders(xPos, 1f, zPos, "Invulnerable", new float[] { 1f, .01f, 1f }));
        }
    }

}
