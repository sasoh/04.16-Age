using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class MapCreatorScript : MonoBehaviour
{
    public MapObjectScript MapObjectPrefab;
    public GameObject MapObjectsParent;
    public int Vertical;
    public int VerticalLength;
    public int Horizontal;
    public int HorizontalLength;
    public int Height;
    public int HeightLength;
    public bool ShouldRebuild = false;
    public float RebuildTimeout = 2.0f;
    float RebuildTime = 0.0f;

    List<MapObjectScript> Map = new List<MapObjectScript>();

    void Start()
    {
        Generate();
    }

    void Update()
    {
        RebuildTime += Time.deltaTime;

        if (ShouldRebuild == true)
        {
            if (RebuildTime >= RebuildTimeout)
            {
                RebuildTime = 0.0f;

                Generate();
            }
        }
    }

    void Generate()
    {
        MapObjectsParent.gameObject.GetComponentsInChildren<MapObjectScript>().ToList<MapObjectScript>().ForEach((MapObjectScript x) => Destroy(x.gameObject));

        Map = new List<MapObjectScript>();

        for (int i = 0; i < Vertical; ++i)
        {
            for (int j = 0; j < Horizontal; ++j)
            {
                float centerX = (j * HorizontalLength) + (HorizontalLength / 2);
                float centerY = Height + HeightLength / 2;
                float centerZ = (i * VerticalLength) + (VerticalLength / 2);
                Vector3 position = new Vector3(centerX, centerY, centerZ);

                MapObjectScript mapObject = (MapObjectScript)Instantiate(MapObjectPrefab, position, transform.rotation);
                mapObject.gameObject.transform.SetParent(MapObjectsParent.transform, false);
                mapObject.Vertical = Vertical;
                mapObject.VerticalLength = VerticalLength;
                mapObject.Horizontal = Horizontal;
                mapObject.HorizontalLength = HorizontalLength;
                mapObject.HeightLength = HeightLength;
                mapObject.name = MapObjectScript.NameForObjectAt(j, i);

                Map.Add(mapObject);
            }
        }
    }
}
