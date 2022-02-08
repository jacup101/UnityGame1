using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values
{


    //int[] {colliders,jumps}
    System.Random rand;
    string[] block;

    string[] individual;
    string[] moving;
    string[] opaqueindividual;
    string[] teleport;
    string[] vertical;
    string[] simulvert;
    string[] forward;
    string[] hordiag;
    string[] fvertical;

    string previousType = "null";
    string previousThrow = "     ";
    public Values(System.Random random)
    {
        rand = random;
        block = new string[] {"XXXX "," XXXX", "XX  X", "X  XX", "  XXX", "XXX  ","JJJJJ","OOOOO","XJJXX","XXJJX","XXXXJ","JXXXX"};
        individual = new string[] {"X    ", " X   ", "  X  ", "   X ", "    X"};
        opaqueindividual = new string[] { "O    ", " O   ", "  O  ", "   O ", "    O" };
        teleport = new string[] { "T    ", " T   ", "  T  ", "   T ", "    T" };
        moving = new string[] { "M    "," M   ","  M  ","    M","    M"};
        vertical = new string[] { "IIIII","I    ","    I" };
        simulvert = new string[] { "VV   ", "   VV", "VVVVV", "VVV  ", "  VVV", " VVV " };
        forward = new string[] { "FFFFF", "F    ", "    F"," F   ","  F  ","   F " };
        hordiag = new string[] { "H    ", " H   ", "  H  ", "   H ", "    H" };
        fvertical = new string[] { "v    ", " v   ", "  v  ", "   v ", "    v", "vvvvv" };

    }
    public List<Colliders> returnColliders(List<Colliders> addTo, int position,string type)
    {
        int chance = 0;
        Debug.Log("this is the type" + type);
        if(type == "mixed")
        {
            chance = rand.Next(1, 5);
            if (chance == 1) return throwCollider(block,"block",addTo, position);

            if (chance == 2 || chance == 3) return throwCollider(individual,"individual",addTo, position);

            if (chance == 4) return throwCollider(moving,"moving",addTo, position);
            
        } if (type == "hardmixed")
        {
            chance = rand.Next(1, 7);
            if (chance == 1) return throwCollider(block,"block",addTo, position);

            if (chance == 2 || chance == 3) return throwCollider(individual,"individual",addTo, position);

            if (chance == 4) return throwCollider(moving,"moving",addTo, position);
            if (chance == 5) return throwCollider(opaqueindividual, "opaqueindividual", addTo, position);
            if (chance == 6) return throwCollider(teleport,"teleport",addTo, position);
        } if(type =="movemixed")
        {
            chance = rand.Next(1, 3);
            if(chance ==1) return throwCollider(moving,"moving",addTo, position);
            if (chance ==2) return throwCollider(teleport, "teleport", addTo, position);
        }
        if (type == "moving")
        {

            return throwCollider(moving,"moving",addTo,position);
        } if(type == "individual")
        {

            return throwCollider(individual,"individual",addTo, position);
        }
        if (type == "opaqueindividual")
        {
            return throwCollider(opaqueindividual, "opaqueindividual", addTo, position);
        }
        if (type == "teleport" )
        {
            return throwCollider(teleport,"teleport",addTo, position);
        }
        if (type == "vertical")
        {
            return throwCollider(vertical,"vertical",addTo, position);
        }
        if (type == "simulvert")
        {
            return throwCollider(simulvert, "simulvert", addTo, position);
        }
        if (type == "forward")
        {
            return throwCollider(forward, "forward", addTo, position);
        }if (type == "hordiag")
        {
            return throwCollider(hordiag, "hordiag", addTo, position);
        }if (type == "fvertical")
        {
            return throwCollider(fvertical, "fvertical", addTo, position);
        } 
        return addTo;
    } 

    private List<Colliders> throwCollider(string[] pool, string type, List<Colliders> addTo, int position)
    {
        string toThrow = previousThrow; int chance = 0;
        while (toThrow.Equals(previousThrow))
        {
            chance = rand.Next(0, pool.Length);
            toThrow = pool[chance];
        }
        
        toThrow = pool[chance]; previousType = type; previousThrow = toThrow;
        return parseString(toThrow, addTo, position);
    }
    


    private List<Colliders> parseString(string toParse, List<Colliders> addTo,int position)
    {

        for(int i=0;i<5;i++)
        {
            string parsed = toParse.Substring(i,1);
            if (parsed == "X") addTo.Add(new Colliders(position, i - 2));
            else if (parsed == "M") addTo.Add(new Colliders(position, i - 2,"Moving Collider" ));
            else if (parsed == "F") addTo.Add(new Colliders(position, i - 2,"Individual Forward Collider" ));
            else if (parsed == "O") addTo.Add(new Colliders(position, i - 2, "Opaque Collider"));
            else if (parsed == "H") addTo.Add(new Colliders(position, i - 2, "Horizontal Diagonal Collider"));
            else if (parsed == "v") addTo.Add(new Colliders(position, i - 2, "Forward Vertical Collider"));
            else if (parsed == "T") addTo.Add(new Colliders(position, i - 2, "Teleporting Collider"));
            else if (parsed == "I") addTo.Add(new Colliders(position, i - 2, "Individual Vertical Collider"));
            else if (parsed == "V") addTo.Add(new Colliders(position, i - 2, "Simultaneous Vertical Collider"));
            else if(parsed == "J") addTo.Add(new Colliders(position,1f, i - 2, "Jumper", new float[] {1.5f,1f,1f}));
        }
        return addTo;
    }


}
