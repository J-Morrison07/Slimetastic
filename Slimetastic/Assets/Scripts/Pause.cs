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
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.pause)
        {
            pause.SetActive(true);
            Time.timeScale = 0.01f;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }

    public void OnHome()
    {
        _input.pause = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
