using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaınMenu : MonoBehaviour
{
    public void Basla()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Cıkıs()
    {
        Application.Quit();
        Debug.Log("Çıkış Yapıldı");
    }
}
