using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] Camera settingsCamera;

    public class Sound
    {
        public static float volume { get { return PlayerPrefs.GetFloat("soundVolume");} set { PlayerPrefs.SetFloat("soundVolume", value);}}
    }

    public class Music
    {
        public static float volume { get { return PlayerPrefs.GetFloat("musicVolume"); } set { PlayerPrefs.SetFloat("musicVolume", value); } }
    }

    internal void ChangeMusicVolume(float volume)
    {
        Music.volume = volume;
        Debug.Log(Music.volume);
    }

    internal void ChangeSoundVolume(float volume)
    {
        Sound.volume = volume;
    }

    internal void BackToMenu()
    {
        settingsMenu.gameObject.SetActive(false);
        settingsCamera.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }


}
