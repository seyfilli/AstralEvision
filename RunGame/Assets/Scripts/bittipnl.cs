using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bittipnl : MonoBehaviour
{

  
    public void yenidenbasla()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
       
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene(0);
      
    }
   

}
