using UnityEngine;
using System.Collections;

public class DebugSquareBoundariesGizmosScript : MonoBehaviour
{
    public int Vertical;
    public int VerticalLength;
    public int Horizontal;
    public int HorizontalLength;
    public int HeightLength;
    public Color GizmoColor = Color.red;

    void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;

        for (int i = 0; i < Vertical; ++i)
        {
            for (int j = 0; j < Horizontal; ++j)
            {
                float centerX = (j * HorizontalLength) + (HorizontalLength / 2);
                float centerY = HeightLength / 2;
                float centerZ = (i * VerticalLength) + (VerticalLength / 2);

                Vector3 center = new Vector3(centerX, centerY, centerZ);
                Vector3 size = new Vector3(HorizontalLength, HeightLength, VerticalLength);

                Gizmos.DrawWireCube(center, size);
            }
        }
    }
}
