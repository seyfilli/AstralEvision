using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudSys : MonoBehaviour
{
    public TextMeshProUGUI _text;

    public Slider slider;


    private void Start()
    {
        loadAudio();
        
    }
    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        _text.text = ((int)(value * 100)).ToString();
        SaveAudio();
    }


    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("AudioVolume",AudioListener.volume);
    }

    private void loadAudio()
    {
        if (PlayerPrefs.HasKey("AudioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
            slider.value = PlayerPrefs.GetFloat("value");
        }
        else
        {
            PlayerPrefs.SetFloat("AudioVolume", 0.5f);
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
            slider.value = PlayerPrefs.GetFloat("AudioVolume");
        }

      
    }
}
