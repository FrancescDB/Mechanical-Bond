using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAnimations : MonoBehaviour
{

    public void LoopedToTrueA()
    {
        GetComponent<Animator>().SetBool("InLoopA", true);
    }
    public void LoopedToFalseA()
    {
        GetComponent<Animator>().SetBool("InLoopA", false);
    }
    public void LoopedToTrueB()
    {
        GetComponent<Animator>().SetBool("InLoopB", true);
    }
    public void LoopedToFalseB()
    {
        GetComponent<Animator>().SetBool("InLoopB", false);
    }
}
