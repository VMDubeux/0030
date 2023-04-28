using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusicControl : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public Slider musicSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.20f);
    }
}
