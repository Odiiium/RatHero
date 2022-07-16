using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] protected internal AudioSource audioSource;

    [SerializeField] protected internal AudioClip[] audioClips;

    internal protected virtual void OnGetDamagedMakeSound(float timeToPlay)
    {
        audioSource.PlayOneShot(audioClips[0], SettingsMenu.Sound.volume);
        CheckTimeToPlay(timeToPlay);
    }
    internal protected virtual void OnGetDamagedMakeSound(float timeToPlay, float volume)
    {
        audioSource.PlayOneShot(audioClips[0], SettingsMenu.Sound.volume * volume);
        CheckTimeToPlay(timeToPlay);
    }

    internal protected virtual void OnDeathMakeSound(float timeToPlay)
    {
        audioSource.PlayOneShot(audioClips[1], SettingsMenu.Sound.volume);
        CheckTimeToPlay(timeToPlay);
    }

    internal protected virtual void OnDeathMakeSound(float timeToPlay, float volume)
    {
        audioSource.PlayOneShot(audioClips[1], SettingsMenu.Sound.volume * volume);
        CheckTimeToPlay(timeToPlay);
    }

    private void CheckTimeToPlay(float timeToPlay)
    {
        if (timeToPlay > 0)
        {
            StartCoroutine(WaitForPartOfAudioClipEnds(timeToPlay));
        }
    }

    internal protected IEnumerator WaitForPartOfAudioClipEnds(float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Stop();
    }
}
