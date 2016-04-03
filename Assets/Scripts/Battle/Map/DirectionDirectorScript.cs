using UnityEngine;
using System.Collections;

public class DirectionDirectorScript : MonoBehaviour
{
    public UnityStandardAssets.Characters.ThirdPerson.AICharacterControl AiControlled;

    private static volatile DirectionDirectorScript instance;

    public static DirectionDirectorScript Instance;
    
    void Start()
    {
        Instance = this;
    }

    public void MapObjectSelected(GameObject mapObject)
    {
        AiControlled.SetTarget(mapObject.transform);
    }
}
