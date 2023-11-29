using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskTimer : MonoBehaviour
{
    public Slider timerTask1;
    public Slider timerTask2;

    private float timer;
    private float maxTimer;
    private bool taskAnimation;
    private Animator playerAnim;

    private void Start()
    {
        timer = 0f;
        taskAnimation = false;

        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (taskAnimation == true)
        {
            maxTimer = playerAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            
            if (timer < maxTimer)
            {
                timer = timer + Time.deltaTime;

                if (playerAnim.name == "Grandson_prefab")
                {
                    timerTask1.maxValue = maxTimer;
                    timerTask1.value = timer;
                }
                if (playerAnim.name == "Grandfather_prefab")
                {
                    timerTask2.maxValue = maxTimer;
                    timerTask2.value = timer;
                }
            }
            else
            {
                timer = 0f;
                taskAnimation = false;
            }
        }
        else
        {
            timer = 0f;
            timerTask1.value = 0f;
            timerTask2.value = 0f;
        }
    }

    public void AnimationStarted()
    {
        taskAnimation = true;
    }
}
