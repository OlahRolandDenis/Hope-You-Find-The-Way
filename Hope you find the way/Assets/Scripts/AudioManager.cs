using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixer theMixer;
    void Start()
    {
        if(PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }


        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }


        if (PlayerPrefs.HasKey("SfxVol"))
        {
            theMixer.SetFloat("SfxVol", PlayerPrefs.GetFloat("SfxVol"));
        }
    }

    
   
}
