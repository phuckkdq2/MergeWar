using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform cube;
    public Transform onMousePrefababe;
    public Vector3 smoothMousePos;
    private Plane plane;
    Vector3 mousePos;
    public Node[,] nodes;
    public int width; 
    public int height;

    void Start()
    {
        CreateGrid();
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

    private void CreateGrid()
    {
        nodes = new Node[width ,height];
        var name = 0; 
        for(int i = 0; i < width ; i++)
        {
            for(int j = 0; j< height ; j++)
            {
                Vector3 worldPos = new Vector3(i * 1.5f + transform.position.x , 0.001f , j*2 + transform.position.z);
                Transform obj = Instantiate(gridCellPrefab, worldPos , Quaternion.identity);
                obj.name = "Cell" + name;
                nodes[i,j] = new Node(true , worldPos, obj);
                name ++;
                obj.parent = transform;
            }
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
            foreach (var node in nodes)
            {
                if(node.cellPos == mousePos && node.isPlaceAble)
                {
                    if(Input.GetMouseButtonUp(0) && onMousePrefababe!= null)
                    {
                        node.isPlaceAble = false;
                        onMousePrefababe.GetComponent<ObjFollowMouse>().isOnGrid = true;
                        onMousePrefababe.position = node.cellPos + new Vector3(0, 0.5f , 0);
                        onMousePrefababe = null;
                    }
                }
            }
        }
    }


}


