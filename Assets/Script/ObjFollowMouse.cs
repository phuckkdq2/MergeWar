using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowMouse : MonoBehaviour
{
    PlaceObjectOnGrid placeObjectOnGrid;
    public bool isOnGrid;

    void Start()
    {
        placeObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
    }
    
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            transform.position = placeObjectOnGrid.smoothMousePos + new Vector3(0, 0.5f, 0);
        }
        
    }
}
