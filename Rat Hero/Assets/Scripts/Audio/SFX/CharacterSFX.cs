using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFX : SFX
{
    internal void OnGetBonusMakeSound(float volume)
    {
        audioSource.PlayOneShot(audioClips[2], SettingsMenu.Sound.volume * volume);
    }
}
