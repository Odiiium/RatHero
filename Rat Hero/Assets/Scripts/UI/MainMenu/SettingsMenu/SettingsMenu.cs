using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] Camera settingsCamera;

    internal static UnityAction<float> onMusicChange, onSoundChange;

    public static class Sound
    {
        public static float volume { get { return PlayerPrefs.GetFloat("soundVolume");} set { PlayerPrefs.SetFloat("soundVolume", value);}}
        
    }

    public static class Music
    {
        public static float volume { get { return PlayerPrefs.GetFloat("musicVolume"); } set { PlayerPrefs.SetFloat("musicVolume", value); } }
    }

    internal static void ChangeMusicVolume(float volume)
    {
        Music.volume = volume;
        onMusicChange?.Invoke(volume);
    }

    internal static void ChangeSoundVolume(float volume)
    {
        Sound.volume = volume;
        onSoundChange?.Invoke(volume);
    }

    internal void BackToMenu()
    {
        settingsMenu.gameObject.SetActive(false);
        settingsCamera.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    internal static void ChangeFieldOfView(float fieldOfViewValue)
    {
        CameraController.cameraFieldOfView = 50 + fieldOfViewValue * 50;
    }


}
