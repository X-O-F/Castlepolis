using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource musicSource;

    public AudioSource sfxSource;
    public AudioClip townClip;
    public AudioClip castleClip;
    public AudioClip introClip;

    public AudioClip eatClip;
    public AudioClip swingSwordClip;
    public AudioClip swingPickaxeClip;

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
        if (sfxSource.clip != eatClip)
        {
            sfxSource.clip = eatClip;
            sfxSource.Play();
        }
    }

    public void PlaySwingSwordSFX()
    {
        if (sfxSource.clip != swingSwordClip)
        {
            sfxSource.clip = swingSwordClip;
            sfxSource.Play();
        }
    }

    public void PlaySwingPickaxeSFX()
    {
        if (sfxSource.clip != swingPickaxeClip)
        {
            sfxSource.clip = swingPickaxeClip;
            sfxSource.Play();
        }
    }
}
