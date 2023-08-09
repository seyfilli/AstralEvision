using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public static bool gameIsPaused = false;
    public GameObject pauseBtn;

    // Bu metot Escape tuþu yerine butona basýldýðýnda çaðrýlacak
    public void OnPauseButtonClicked()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;

        pauseBtn.SetActive(true);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;

        // Pause menüsü açýldýðýnda butonu devre dýþý býrak
        pauseBtn.SetActive(false);
    }
}
