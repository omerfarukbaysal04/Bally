using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;

    void Start()
    {
        UpdateOffset();
    }
    public void UpdateOffset()
    {
        offset = transform.position - ball.transform.position;
    }
    void LateUpdate()
    {
        Vector3 newPosition = ball.transform.position + offset;
        newPosition.z = transform.position.z; 
        transform.position = newPosition;
    }
    public void ForceUpdatePosition()
    {
        Vector3 newPosition = ball.transform.position+offset;
        newPosition.x=0.0f;
        newPosition.y=0.0f;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}


