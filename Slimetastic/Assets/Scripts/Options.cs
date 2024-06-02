using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject homeButton;
    public GameObject optionsButton;
    public GameObject backButton;
    public GameObject optionsMenu;

    private void Start()
    {
        homeButton.SetActive(true);
        optionsButton.SetActive(true);
        backButton.SetActive(false);
        optionsMenu.SetActive(false);
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
}
