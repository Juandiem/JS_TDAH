using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Slider>().value = MusicManager.instance.GetVolume();
    }

    public void ChangeVolume()
    {
        if(GetComponent<Slider>().value != MusicManager.instance.GetVolume())
        {
            MusicManager.instance.SetVolume(GetComponent<Slider>().value);
        }
    }
}
