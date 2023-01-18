using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartGame : MonoBehaviour
{
    public AudioClip song;
    public void Start()
    {
        MusicManager.instance.setAudioClip(song);
        MusicManager.instance.play();
    }
}
