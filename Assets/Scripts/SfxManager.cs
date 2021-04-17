using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{

    public AudioSource Audio;

    public AudioClip MenuSelection;

    public AudioClip itemPickup;

    public AudioClip dialogBlip;

    public AudioClip LevelComplete;

    public AudioClip ArtifactFound;

    public AudioClip PlayerUpgrade;

    public AudioClip PlayerDeath;

    public static SfxManager sfxInstance;


    // OtherAudioClips

    public void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
