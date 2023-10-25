using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform cube;
    public Transform onMousePrefababe;
    public Vector3 smoothMousePos;
    private Plane plane;
    Vector3 mousePos;
    [SerializeField] private List<Transform> PosChamp;

    void Start()
    {
        //CreateGrid();
        plane = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
        GetMousePosOnGrid();
    }

    public void OnMouseClick()
    {
        if(!onMousePrefababe)
        {
            onMousePrefababe = Instantiate(cube, mousePos,Quaternion.identity);
        }
    }



    void GetMousePosOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out var enter))
        {
            mousePos = ray.GetPoint(enter);
            smoothMousePos = mousePos;
            mousePos.y = 0 ;
            mousePos = Vector3Int.RoundToInt(mousePos);
            // foreach (var node in nodes)
            // {
            //     if(node.cellPos == mousePos && node.isPlaceAble)
            //     {
            //         if(Input.GetMouseButtonUp(0) && onMousePrefababe!= null)
            //         {
            //             node.isPlaceAble = false;
            //             onMousePrefababe.GetComponent<ObjFollowMouse>().isOnGrid = true;
            //             onMousePrefababe.position = node.cellPos + new Vector3(0, 0.5f , 0);
            //             onMousePrefababe = null;
            //         }
            //     }
            // }
        }
    }
}


