using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Vector3 currentCheckpoint;

    void Awake()
    {
        if(instance == null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentCheckpoint = new Vector3(-9, 0, -2);
        ResetCheckPoint();
    }
    
    public void SetCheckPoint(Vector3 checkpointPosition)
    {
        currentCheckpoint = checkpointPosition;
    }

    public Vector3 GetCheckpoint()
    {
        return currentCheckpoint;
    }

    public void ResetCheckPoint()
    {
        currentCheckpoint = new Vector3(-9, 0, -2);
    }
}

