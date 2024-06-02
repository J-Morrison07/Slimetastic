using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class Pause : MonoBehaviour
{
    public StarterAssetsInputs _input;
    public GameObject pause;
    public GameObject pauseicon;
    public GameObject playicon;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
        pauseicon.SetActive(true);
        playicon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.pause)
        {
            pause.SetActive(true);
            player.GetComponent<ThirdPersonController>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            pauseicon.SetActive(false);
            playicon.SetActive(true);
        } else
        {
            pause.SetActive(false);
            player.GetComponent<ThirdPersonController>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
            pauseicon.SetActive(true);
            playicon.SetActive(false);
        }
    }

    public void OnHome()
    {
        _input.pause = false;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
