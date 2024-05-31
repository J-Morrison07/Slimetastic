using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour {
    public AudioSource audio;
    public Vector3 offset = new Vector3(0, 0, 0);
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.hearts--;
        audio.Play();
        other.gameObject.GetComponent<CharacterController>().Move(Vector3.forward+offset);
    }
}
