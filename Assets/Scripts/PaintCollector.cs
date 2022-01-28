using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollector : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Movement m_Movement;
    private int redDyeNum;
    private int yellowDyeNum;
    private int blueDyeNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YellowDye"))
        {
            Destroy(other.gameObject);
            yellowDyeNum++;

        }
        else 
        if (other.gameObject.CompareTag("BlueDye"))
        {
            Destroy(other.gameObject);
            blueDyeNum++;

        }
        else
        if (other.gameObject.CompareTag("RedDye"))
        {
            Destroy(other.gameObject);
            redDyeNum++;

        }
        else
        if (other.gameObject.CompareTag("GameEndCheck"))
        {
            Destroy(other.gameObject);
            m_Animator.SetBool("shoot", true);
            m_Movement.enabled = false;
        }
    }
}
