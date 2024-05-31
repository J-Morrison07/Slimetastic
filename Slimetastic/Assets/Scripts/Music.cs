using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Song1;
    public AudioSource Song2;
    // Start is called before the first frame update
    void Start()
    {
        Song1.enabled = true;
        Song2.enabled = false;
        StartCoroutine(Song2Wait(Song1.clip.length));
    }

    IEnumerator Song2Wait(float time)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        Song1.Pause();
        Song1.enabled = false;
        Song2.enabled = true;
        Song2.Play();
    }
}
