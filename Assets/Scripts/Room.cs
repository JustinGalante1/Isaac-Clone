using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    string id="-1";
    string name;

    int row=0;
    int col=0;

    bool northDoor = false;
    bool eastDoor = false;
    bool southDoor = false;
    bool westDoor = false;
    
    public Room(int row, int col, string id)
    {
        this.row = row;
        this.col = col;
        this.id = id;
    }

    public int getNumberOfDoors()
    {
        int count = 0;
        if (northDoor)
        {
            count += 1;
        }
        if (eastDoor)
        {
            count += 1;
        }
        if (southDoor)
        {
            count += 1;
        }
        if (westDoor)
        {
            count += 1;
        }
        return count;
    }

    public void setName()
    {
        this.name = getNumberOfDoors()+" ";
        if (northDoor)
        {
            name += "N";
        }
        if (eastDoor)
        {
            name += "E";
        }
        if (southDoor)
        {
            name += "S";
        }
        if (westDoor)
        {
            name += "W";
        }
        name += " Room";
    }

    public string getName()
    {
        return this.name;
    }

}
