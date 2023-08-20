using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        if (SwipeUp || SwipeManager.swipeUp)
        {
            m_Animator.Play("Jump");
        }
        else if (SwipeDown || SwipeManager.swipeDown)
        {
            m_Animator.Play("Roll");
        }
    
    }
}
