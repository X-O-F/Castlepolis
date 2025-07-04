using System;
using UnityEngine;

// Script to play clips through the MusicManager triggered by Animation Events (for NPCs etc)
public class TriggerAudio : MonoBehaviour
{
    public string audioToTrigger;

    public void TriggerMusicManager(string audioToTrigger)
    {
        switch (audioToTrigger)
        {
            case "hammer":
                MusicManager.instance.PlayHammerSFX();
                break;
            default:
                break;
        }
    }
}
