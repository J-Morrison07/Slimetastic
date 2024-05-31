using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int hearts = 5;
    public static int score = 0;
    public TextMeshProUGUI heartsText;
    public TextMeshProUGUI scoreText;
    public AudioSource heartUp;
    public AudioSource death;
    // Update is called once per frame
    void Update()
    {
        heartsText.text = "x"+ hearts.ToString();
        scoreText.text = "x" + score.ToString();
        if (score >= 5)
        {
            hearts++;
            heartUp.Play();
            score = 0;
        }
        if(hearts < 1)
        {
            death.Play();
            StartCoroutine(Wait(0.5f));
            hearts = 5;
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(LevelLoader.level);
    }
}
