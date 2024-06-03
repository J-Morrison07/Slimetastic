using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Flag : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        LevelLoader.level++;
        animator.ResetTrigger("Load");
        OnPlay();
        other.gameObject.GetComponent<ThirdPersonController>().enabled = false;
        player = other.gameObject;
    }

    public void OnPlay()
    {
        animator.SetTrigger("Load");
        audioSource.Play();
        StartCoroutine(Wait(1));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        PlayerPrefs.SetInt("Level", LevelLoader.level);
        SceneManager.LoadScene(LevelLoader.level);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.gameObject.GetComponent<ThirdPersonController>().enabled = true;
    }
}
