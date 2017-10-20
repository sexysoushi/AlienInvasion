using UnityEngine;
using System;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class BlinkingCtrl : MonoBehaviour
{
	private Animator animator;
    public int from = 2;
	public int to = 5;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(blink());
     }

    // Update is called once per frame
    void Update()
    {
	
     }

    IEnumerator blink()
    {
        while (true)
        {
            System.Random random = new System.Random();
            int value = random.Next(from,to);
            //Debug.Log("Waiting for " +value + " seconds");
            yield return new WaitForSeconds(value);
            animator.SetBool("Blinking", true);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("Blinking", false);
        }

    }
}
