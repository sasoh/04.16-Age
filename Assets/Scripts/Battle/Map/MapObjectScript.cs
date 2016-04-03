using UnityEngine;
using System.Collections;

public class MapObjectScript : MonoBehaviour
{
    public int Vertical;
    public int VerticalLength;
    public int Horizontal;
    public int HorizontalLength;
    public int HeightLength;
    
    public Color GizmoColorBase = Color.red;
    public Color GizmoColorHighlight = Color.blue;
    public Color GizmoColorSelected = Color.green;
    Color GizmoColor = Color.red;

    void Start()
    {
        ResizeBoxCollider();
    }

    void OnDrawGizmos()
    {        
        Vector3 size = new Vector3(HorizontalLength, HeightLength, VerticalLength);
        Gizmos.color = GizmoColor;
        Gizmos.DrawWireCube(transform.position, size);
    }

    void ResizeBoxCollider()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.center = new Vector3();
        collider.size = new Vector3(HorizontalLength, HeightLength, VerticalLength);
    }

    public static string NameForObjectAt(int horizontal, int vertical)
    {
        return "MapObject [" + vertical + "][" + horizontal + "]";
    }

    void OnMouseEnter()
    {
        GizmoColor = GizmoColorHighlight;
    }

    void OnMouseDown()
    {
        GizmoColor = GizmoColorSelected;

        Debug.Log("Clicked on " + gameObject);
    }

    void OnMouseExit()
    {
        GizmoColor = GizmoColorBase;
    }
}
