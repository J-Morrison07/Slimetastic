using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnd : MonoBehaviour
{
    public float num;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("End", Random.Range(0f,5f));
        num = animator.GetFloat("End");
        animator.SetTrigger("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
