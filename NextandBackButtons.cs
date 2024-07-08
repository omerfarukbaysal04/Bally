using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextandBackButtons : MonoBehaviour
{
   public void Next()
   {
    SceneManager.LoadScene("Tips1");
   }
   public void Continue()
   {
      SceneManager.LoadScene("Tips2");
   }
   public void Back()
   {
    SceneManager.LoadScene("Tips");  
   }
   public void Level1()
   {
    SceneManager.LoadScene("Level1");  
   }
   public void Level3()
   {
      SceneManager.LoadScene("Level3");
   }
   public void BackTips1()
   {
      SceneManager.LoadScene("Tips1");
   }
   public void BackToMenu()
   {
      SceneManager.LoadScene("Main Menu");
   }
}
