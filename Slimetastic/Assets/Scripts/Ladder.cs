using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float startSpeed;
    public AudioSource ladderSound;
    private void OnTriggerEnter(Collider other)
    {
        startSpeed = other.gameObject.GetComponent<ThirdPersonController>().MoveSpeed;
        other.gameObject.GetComponent<Animator>().SetTrigger("Climb");
        other.gameObject.GetComponent<ThirdPersonController>().MoveSpeed = 0;
        ladderSound.Play();
        StartCoroutine(Wait(1, other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<ThirdPersonController>().MoveSpeed = startSpeed;
        ladderSound.Pause();
    }

    IEnumerator Wait(float time, GameObject player)
    {
        yield return new WaitForSeconds(time);
        player.gameObject.GetComponent<Animator>().ResetTrigger("Climb");
        player.gameObject.GetComponent<CharacterController>().Move((Vector3.up * 2));
        player.gameObject.GetComponent<CharacterController>().Move(-(Vector3.forward * 0.05f));
    }

}
