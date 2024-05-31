using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathZone : MonoBehaviour
{

    public Vector3 SpawnPoint = new Vector3(0,0,0);
    public Quaternion SpawnRotation = Quaternion.identity;
    public AudioSource DeathAudio;
    public AudioSource WhooshSound;
    public Animator CanvasAnimator;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterController>().enabled = false;
        other.GetComponent<ThirdPersonController>().enabled = false;
        other.GetComponent<Animator>().SetBool("Died", true);
        StartCoroutine(RespawnWait(1, other.gameObject));
        StartCoroutine(InputWait(2, other.gameObject));
        CanvasAnimator.SetTrigger("Respwan");
        WhooshSound.Play();
        DeathAudio.Play();
    }

    IEnumerator RespawnWait(float time, GameObject player)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        WhooshSound.Play();
        PlayerStats.hearts--;
        player.gameObject.transform.position = SpawnPoint;
        player.gameObject.transform.rotation = SpawnRotation;
        player.GetComponent<Animator>().SetBool("Died", false);
        CanvasAnimator.ResetTrigger("Respwan");
    }

    IEnumerator InputWait(float time, GameObject player)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        player.gameObject.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<ThirdPersonController>().enabled = true;
    }
}
