using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders
{
    string specialTrait;
    private float[] pos;
    private float[] size;
    private string name;
    private static int id = 0;
    public Colliders(int xPos, int zPos)
    {
        specialTrait = "null";
        pos = new float[] { xPos, 1.5f, zPos };
        size = new float[] { 1, 1, 1 };
        name = "Collider " + id; id++;
    }
    public Colliders(int xPos, int zPos, string special)
    {
        specialTrait = special;
        pos = new float[] { xPos, 1.5f, zPos };
        size = new float[] { 1, 1, 1 };
        name = specialTrait + " " + id; id++;
    }
    public Colliders(int xPos, float yPos, int zPos, string special, float[] spSize)
    {
        specialTrait = special;
        pos = new float[] { xPos, yPos, zPos };
        size = spSize;
        name = specialTrait + " " + id; id++;
    }
    public float[] getPos() { return pos; }
    public float[] getSize() { return size; }
    public string getName() { return name; }
    public string getTrait() { return specialTrait; }
}
