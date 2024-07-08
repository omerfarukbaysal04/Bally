using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {   UnlockNewLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    void UnlockNewLevel()
    {
        PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex+1);
        PlayerPrefs.SetInt("UnlockedLevel",PlayerPrefs.GetInt("UnlockedLevel",1)+1);
        PlayerPrefs.Save();
    }
}
