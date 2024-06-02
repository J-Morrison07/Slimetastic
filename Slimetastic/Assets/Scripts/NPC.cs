using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class NPC : MonoBehaviour
{
    [Header("NPC Info")]
    public string name;
    public List<string> pages;
    public int pageIndex = 0;
    public bool playerDetection = false;
    public float _timeoutDelta;
    public float Timeout = 0.11f;
    
    [Header("GameObjects")]
    public GameObject player;
    private StarterAssetsInputs _input;
    private ThirdPersonController _thirdPersonController;
    public GameObject dialogueBubble;
    public List<GameObject> interactIcons = new List<GameObject>();
    public int interactIconsIndex = 0;
    //public GameObject talkButton;
    public GameObject textBox; 
    public GameObject textBoxShadow;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI textBoxText;
    public Animator animator;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _input = player.GetComponent<StarterAssetsInputs>();
        _thirdPersonController = player.GetComponent<ThirdPersonController>();
        dialogueBubble.SetActive(false);
        //talkButton.SetActive(false);
        interactIcons[0].SetActive(false);
        interactIcons[1].SetActive(false);
        interactIcons[2].SetActive(false);
        textBox.SetActive(false);
        textBoxShadow.SetActive(false);
        dialogueBubble.GetComponent<Animator>().ResetTrigger("Close");
        //talkButton.GetComponent<Animator>().ResetTrigger("Hide");
        interactIcons[0].GetComponent<Animator>().ResetTrigger("Hide");
        interactIcons[1].GetComponent<Animator>().ResetTrigger("Hide");
        interactIcons[2].GetComponent<Animator>().ResetTrigger("Hide");
        textBoxText.text = pages[0];
        animator.ResetTrigger("Talk");
    }

    // Update is called once per frame
    void Update()
    {
        interactIconsIndex = PlayerPrefs.GetInt("Icons");
        if (playerDetection)
        {
            dialogueBubble.SetActive(true);
            //talkButton.SetActive(true);
            if(interactIconsIndex == 0)
            {
                interactIcons[0].SetActive(true);
                interactIcons[1].SetActive(false);
                interactIcons[2].SetActive(false);
            }
            if (interactIconsIndex == 1)
            {
                interactIcons[0].SetActive(false);
                interactIcons[1].SetActive(true);
                interactIcons[2].SetActive(false);
            }
            if (interactIconsIndex == 2)
            {
                interactIcons[0].SetActive(false);
                interactIcons[1].SetActive(false);
                interactIcons[2].SetActive(true);
            }
            if (_input.interact)
            {
                textBoxShadow.SetActive(true);
                textBox.SetActive(true);
                _thirdPersonController.enabled = false;
                nameText.text = name;
                StartCoroutine(Interact(0.1f));
            }
            
        } else
        {
            // reset the timeout timer
            _timeoutDelta = Timeout;
        }
        // timeout
        if (_timeoutDelta >= 0.0f)
        {
            _timeoutDelta -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerDetection = true;
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueBubble.GetComponent<Animator>().SetTrigger("Close");
        //talkButton.GetComponent<Animator>().SetTrigger("Hide");
        interactIcons[0].GetComponent<Animator>().SetTrigger("Hide");
        interactIcons[1].GetComponent<Animator>().SetTrigger("Hide");
        interactIcons[2].GetComponent<Animator>().SetTrigger("Hide");
        StartCoroutine(Wait(0.6f));
        playerDetection = false;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        dialogueBubble.SetActive(false);
        interactIcons[0].SetActive(false);
        interactIcons[1].SetActive(false);
        interactIcons[2].SetActive(false);
    }

    IEnumerator Interact(float time)
    {
        // interact
        if (_input.interact && _timeoutDelta <= 0.0f)
        {
            
            _timeoutDelta = Timeout;
            yield return new WaitForSeconds(time);
            if (pageIndex > pages.Count - 1)
            {
                pageIndex = 0;
                textBoxText.text = pages[pageIndex];
                textBox.SetActive(false);
                textBoxShadow.SetActive(false);
                audioSource.Pause();
                _thirdPersonController.enabled = true;
                animator.ResetTrigger("Talk");
            } else
            {
                audioSource.Play();
                animator.SetTrigger("Talk");
                textBoxText.text = pages[pageIndex];
                pageIndex++;
            }
        }
    }
}
