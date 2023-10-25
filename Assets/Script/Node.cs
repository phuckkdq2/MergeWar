using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public bool isPlaceAble;
    public Vector3 cellPos;
    public Transform obj;

    public Node(bool isPlaceAble, Vector3 cellPos , Transform obj)
    {
        this.isPlaceAble = isPlaceAble;
        this.cellPos = cellPos ;
        this.obj = obj;
    }
}
