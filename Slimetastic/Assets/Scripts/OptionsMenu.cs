using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject backround;
    public GameObject playButton;
    public GameObject resetButton;
    public GameObject tutorialButton;
    public GameObject quitButton;
    public GameObject creditsButton;
    public GameObject backButton;

    private void Start()
    {
        optionsMenu.SetActive(false);
        backButton.SetActive(false);
        backround.SetActive(false);
    }
    public void OnOptions()
    {
        optionsMenu.SetActive(true);
        backButton.SetActive(true);
        backround.SetActive(true);
        playButton.GetComponent<Button>().enabled = false;
        resetButton.GetComponent<Button>().enabled = false;
        tutorialButton.GetComponent<Button>().enabled = false;
        quitButton.GetComponent<Button>().enabled = false;
        creditsButton.GetComponent<Button>().enabled = false;
    }

    public void OnBack()
    {
        optionsMenu.SetActive(false);
        backButton.SetActive(false);
        backround.SetActive(false);
        playButton.GetComponent<Button>().enabled = true;
        resetButton.GetComponent<Button>().enabled = true;
        tutorialButton.GetComponent<Button>().enabled = true;
        quitButton.GetComponent<Button>().enabled = true;
        creditsButton.GetComponent<Button>().enabled = true;
    }
}
