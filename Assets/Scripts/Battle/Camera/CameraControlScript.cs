using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour
{
    public float MovementSpeed = 10.0f;

    void Update()
    {
        InputData input = InputManagerScript.GetInput();
        ProcessInput(input);
    }

    void ProcessInput(InputData input)
    {
        Vector3 position = transform.position;

        position.x += input.Horizontal * MovementSpeed;
        position.z += input.Vertical * MovementSpeed;

        transform.localPosition = position;
    }
}
