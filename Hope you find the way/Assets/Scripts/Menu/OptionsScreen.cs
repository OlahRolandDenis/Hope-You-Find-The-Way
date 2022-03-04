using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
public class OptionsScreen : MonoBehaviour  
    //doua meniuri la options + brightness
{
    public Toggle fullscreenTog, vsyncTog;
    public List<ResolutionItem> resolutions = new List<ResolutionItem>();
    private int selectedResolution;
    public TMP_Text ResolutionLabel;

    public AudioMixer theMixer;
    public TMP_Text MasterLabel, MusicLabel, SfxLabel;
    public Slider MasterSlider, MusicSlider, SfxSlider;     

    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;

        }
        else
        {
            vsyncTog.isOn = true;
        }
        bool foundResolution = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundResolution = true;
                selectedResolution = i;
                UpdateResolutionLabel();
            }
        }
        if(!foundResolution)
        {
            ResolutionItem newResolution = new ResolutionItem();
            newResolution.horizontal = Screen.width;
            newResolution.vertical = Screen.height;
            resolutions.Add(newResolution);
            selectedResolution = resolutions.Count-1;

            UpdateResolutionLabel();
        }

        float vol = 0;
        theMixer.GetFloat("MasterVol", out vol);
        MasterSlider.value = vol;
        theMixer.GetFloat("MusicVol", out vol);
        MusicSlider.value = vol;
        theMixer.GetFloat("SfxVol", out vol);
        SfxSlider.value = vol;
        MasterLabel.text = Mathf.RoundToInt(MasterSlider.value + 80).ToString();
        MusicLabel.text = Mathf.RoundToInt(MusicSlider.value + 80).ToString();
        SfxLabel.text = Mathf.RoundToInt(SfxSlider.value + 80).ToString();
    }
   
    
    public void ResolutionLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResolutionLabel();
    }
    public void ResolutionRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count-1)
        {
            selectedResolution = resolutions.Count-3; //trebuie valoarea exacta 
        }
        UpdateResolutionLabel();
    }
    public void UpdateResolutionLabel()
    {
        ResolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + "x" + resolutions[selectedResolution].vertical.ToString();  
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;
        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount =1 ;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);

    }


    public void SetMasterVol()
    {
        MasterLabel.text = Mathf.RoundToInt(MasterSlider.value + 80).ToString();
        theMixer.SetFloat("MasterVol", MasterSlider.value);
        PlayerPrefs.SetFloat("MasterVol", MasterSlider.value);

    }
    public void SetMusicVol()
    {
        MusicLabel.text = Mathf.RoundToInt(MusicSlider.value + 80).ToString();
        theMixer.SetFloat("MusicVol", MusicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", MusicSlider.value);

    }

    public void SetSfxVol()
    {
        SfxLabel.text = Mathf.RoundToInt(SfxSlider.value + 80).ToString();
        theMixer.SetFloat("SfxVol", SfxSlider.value);
        PlayerPrefs.SetFloat("SfxVol", SfxSlider.value);
    }

}
[System.Serializable]
public class ResolutionItem
{
    public int horizontal, vertical;
}
