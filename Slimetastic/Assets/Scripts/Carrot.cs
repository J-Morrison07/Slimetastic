using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public MeshRenderer mesh;
    public Collider collider;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.score++;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyWait(1));
        mesh.enabled = false;
        collider.enabled = false;
    }

    IEnumerator DestroyWait(float time)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
