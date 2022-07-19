using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicThemeController : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClipArray;
    internal AudioSource audioSource;

    static internal int clipIndex;

    private void OnEnable()
    {
        SettingsMenu.onMusicChange += ChangeMusicVolume;
    }

    private void OnDisable()
    {
        SettingsMenu.onMusicChange -= ChangeMusicVolume;
    }

    private void Awake()
    {
        clipIndex = Random.Range(0, audioClipArray.Length);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClipArray[clipIndex], SettingsMenu.Music.volume);
        StartCoroutine(WaitForNextMusicTheme(audioClipArray[clipIndex].length));
    }

    public IEnumerator WaitForNextMusicTheme(float time)
    {
        clipIndex++;
        if (clipIndex == audioClipArray.Length) clipIndex = 0;
        yield return new WaitForSeconds(time);
        audioSource.PlayOneShot(audioClipArray[clipIndex]);
        StartCoroutine(WaitForNextMusicTheme(audioClipArray[clipIndex].length));
    }

    private void ChangeMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
