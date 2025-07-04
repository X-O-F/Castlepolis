using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource workerHammerSource;

    [Header("Music Clips")]
    public AudioClip townClip;
    public AudioClip castleClip;
    public AudioClip introClip;

    [Header("SFX Clips")]
    public AudioClip eatClip;
    public AudioClip swingSwordClip;
    public AudioClip swingPickaxeClip;
    public AudioClip buttonClip;
    public AudioClip coinsClip;
    public AudioClip doorOpenClip;
    public AudioClip doorCloseClip;
    public AudioClip teleportClip;
    public AudioClip popClip;
    public AudioClip hammerClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional, if scene changing later
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (musicSource != null)
            StartCoroutine(initMusic());
    }

    public void PlayTownMusic()
    {
        if (musicSource.clip != townClip)
        {
            musicSource.clip = townClip;
            musicSource.Play();
        }
    }

    public void PlayCastleMusic()
    {
        if (musicSource.clip != castleClip)
        {
            musicSource.clip = castleClip;
            musicSource.Play();
        }
    }

    public void PlayIntroMusic()
    {
        if (musicSource.clip != introClip)
        {
            musicSource.clip = introClip;
            musicSource.Play();
        }
    }

    IEnumerator initMusic()
    {
        PlayIntroMusic();
        yield return new WaitForSeconds(7f);
        PlayTownMusic();
    }

    public void PlayEatSFX()
    {
        sfxSource.clip = eatClip;
        sfxSource.Play();
    }

    public void PlaySwingSwordSFX()
    {
        sfxSource.clip = swingSwordClip;
        sfxSource.Play();
    }

    public void PlaySwingPickaxeSFX()
    {
        sfxSource.clip = swingPickaxeClip;
        sfxSource.Play();
    }
    public void PlayButtonSFX()
    {
        sfxSource.clip = buttonClip;
        sfxSource.Play();
    }
    public void PlayCoinsSFX()
    {
        sfxSource.clip = coinsClip;
        sfxSource.Play();
    }

    public void PlayDoorOpenSFX()
    {
        sfxSource.clip = doorOpenClip;
        sfxSource.Play();
    }

    public void PlayDoorCloseSFX()
    {
        sfxSource.clip = doorCloseClip;
        sfxSource.Play();
    }

    public void PlayTeleportSFX()
    {
        sfxSource.clip = teleportClip;
        sfxSource.Play();
    }

    public void PlayPopSFX()
    {
        sfxSource.clip = popClip;
        sfxSource.Play();
    }

    public void PlayHammerSFX()
    {
        workerHammerSource.PlayOneShot(hammerClip);
    }
}
