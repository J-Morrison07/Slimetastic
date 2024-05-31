using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EnemyHitBox : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem particles;
    public AudioSource SFX;
    public Animator animator;
    public float time;
    public Vector3 nockback = new Vector3(0,2.5f,0);
    public bool hit = false;
    private void OnTriggerEnter(Collider other)
    {
        if (hit == false)
        {
            StartCoroutine(DestroyWait(time, other));
            animator.SetTrigger("die");
            particles.Play();
            SFX.PlayDelayed(0.2f);
            other.gameObject.GetComponent<CharacterController>().Move(nockback);
            other.gameObject.GetComponent<Animator>().SetBool("Jump", true);
            hit = true;
        }
    }
    IEnumerator DestroyWait(float time, Collider other)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(this.time);
        Destroy(player);
        other.gameObject.GetComponent<Animator>().SetBool("Jump", false);
    }
}
