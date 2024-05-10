using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    public int Speed;
    public int Height;
    void Update()
    {

        Vector3 desiredPosition = Player.position + new Vector3(-4,Height,-4);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Speed* Time.deltaTime);
        transform.position = smoothedPosition;



    }
}
