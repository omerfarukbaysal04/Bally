using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TipsButton : MonoBehaviour
{
    
    public void LoadCredits()
    {
        SceneManager.LoadScene("Tips");
    }
}
