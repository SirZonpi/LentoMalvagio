using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public AudioMixerGroup musica;
    public AudioMixerGroup sfx;

    public Slider sliderMusica;
    public Slider sliderSfx;

    public GameObject panelOpzioni;
    public  GameObject panelCredits;

    public void SetVolumeMusica(float sliderValue)
    {
        musica.audioMixer.SetFloat("MusicaVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicaVol", sliderValue);
    }

    public void SetVolumeSFX(float sliderValue )
    {
        sfx.audioMixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SfxVol", sliderValue);
    }

    public void ApriPannelloOpzioni()
    {
        panelOpzioni.SetActive(true);
    }

    public void ChiudiPannelloOpzioni()
    {
        panelOpzioni.SetActive(false);
    }

    public void ChiudiPannelloCredits()
    {
        panelCredits.SetActive(false);
    }

    public void ApriPannelloCredits()
    {
        panelCredits.SetActive(true);
    }

    private void Start()
    {

        SetVolumeMusica(PlayerPrefs.GetFloat("MusicaVol"));
        SetVolumeSFX(PlayerPrefs.GetFloat("SfxVol"));

        sliderMusica.value = PlayerPrefs.GetFloat("MusicaVol");
        sliderSfx.value = PlayerPrefs.GetFloat("SfxVol");

        if(panelOpzioni!=null)
        panelOpzioni.SetActive(false);


        if (panelCredits != null)
        panelOpzioni.SetActive(false);

    }


}
