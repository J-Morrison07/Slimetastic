using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class Options : MonoBehaviour
{
    public GameObject homeButton;
    public GameObject optionsButton;
    public GameObject backButton;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;
    public Toggle fullscreen;
    public TMP_Dropdown reslutionsDropdown;
    public TMP_Dropdown iconsDropdown;
    public List<GameObject> pauseIcons = new List<GameObject>();
    public List<GameObject> interactIcons = new List<GameObject>();
    public List<GameObject> nextInteractIcons = new List<GameObject>();
    public float volume;
    public float musicVolume;
    public float effectsVolume;
    Resolution[] resolutions;
    public int icons;
    

    private void Start()
    {
        homeButton.SetActive(true);
        optionsButton.SetActive(true);
        backButton.SetActive(false);
        optionsMenu.SetActive(false);

        volume = PlayerPrefs.GetFloat("Volume", 0);
        SetVolume(volume);
        masterSlider.value = volume;
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        SetMusicVolume(musicVolume);
        musicSlider.value = musicVolume;
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0);
        SetEffectsVolume(effectsVolume);
        effectsSlider.value = effectsVolume;

        resolutions = Screen.resolutions;
        reslutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentReslutionIndex = resolutions.Length;

        for (int i = 0; i < resolutions.Length; i++)
        {
           string option = resolutions[i].width + " X " + resolutions[i].height;
           options.Add(option);
            
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentReslutionIndex = i;
            }
        }

        reslutionsDropdown.AddOptions(options);
        reslutionsDropdown.value = currentReslutionIndex;
        reslutionsDropdown.RefreshShownValue();

        icons = PlayerPrefs.GetInt("Icons", 0);
        SetPauseIcons(icons);
        iconsDropdown.value = icons;
    }

    public void OnOptions()
    {
        homeButton.SetActive(false);
        optionsButton.SetActive(false);
        backButton.SetActive(true);
        optionsMenu.SetActive(true);
    }

    public void OnBack()
    {
        homeButton.SetActive(true);
        optionsButton.SetActive(true);
        backButton.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        this.volume = PlayerPrefs.GetFloat("Volume", 0);
        audioMixer.SetFloat("Volume", this.volume);
    }
    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        audioMixer.SetFloat("MusicVolume", musicVolume);
    }
    public void SetEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat("EffectsVolume", volume);
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0);
        audioMixer.SetFloat("EffectsVolume", effectsVolume);
    }

    public void SetFullsreen(bool isFullsreen)
    {
        fullscreen.isOn = isFullsreen;
        Screen.fullScreen = isFullsreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetPauseIcons(int iconSet)
    {
        PlayerPrefs.SetInt("Icons", iconSet);

        if (iconSet == 0) 
        {
            pauseIcons[0].SetActive(true);
            pauseIcons[1].SetActive(false);
            pauseIcons[2].SetActive(false);
            nextInteractIcons[0].SetActive(true);
            nextInteractIcons[1].SetActive(false);
            nextInteractIcons[2].SetActive(false);
        } else if (iconSet == 1)
        {
            pauseIcons[0].SetActive(false);
            pauseIcons[1].SetActive(true);
            pauseIcons[2].SetActive(false);
            nextInteractIcons[0].SetActive(false);
            nextInteractIcons[1].SetActive(true);
            nextInteractIcons[2].SetActive(false);
        } else
        {
            pauseIcons[0].SetActive(false);
            pauseIcons[1].SetActive(false);
            pauseIcons[2].SetActive(true);
            nextInteractIcons[0].SetActive(false);
            nextInteractIcons[1].SetActive(false);
            nextInteractIcons[2].SetActive(true);
        }
    }
}
