using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    [SerializeField] int prefab;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab == 1)
        {
            RunSonAnim();
        }
        else
        {
            RunFatherAnim();
        }

       
    }

    private void RunSonAnim()
    {
        if(rb.velocity.magnitude > 0)
        {
            anim.Play("CorrerNieto");
        }
        else
        {
            anim.Play("IdleNieto");
        }
    }
    private void RunFatherAnim()
    {
        if (rb.velocity.magnitude > 0)
        {
            anim.Play("CorrerAbuelo");
        }
        else
        {
            anim.Play("IdleAbuelo");
        }
    }
}
