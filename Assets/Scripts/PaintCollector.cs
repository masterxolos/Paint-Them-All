using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollector : MonoBehaviour
{
    private int dyeNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dye"))
        {
            Destroy(other.gameObject);
            dyeNum++;
            Debug.Log(dyeNum);
        }
    }
}
