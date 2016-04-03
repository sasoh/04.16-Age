using UnityEngine;

struct InputData
{
    public float Horizontal;
    public float Vertical;
}

class InputManagerScript
{
    public static InputData GetInput()
    {
        InputData result;

        result.Horizontal = Input.GetAxis("Horizontal");
        result.Vertical = Input.GetAxis("Vertical");

        return result;
    }
}