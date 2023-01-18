using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    AudioSource audioSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.4f;
        audioSource.loop = true;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void setAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
    }
    public void play()
    {
        audioSource.Play();
    }
    public float GetVolume()
    {
        return audioSource.volume;
    }
}
