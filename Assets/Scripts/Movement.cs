using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Touch Settings
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;
    [SerializeField, ReadOnly] private float movementSpeed;
    [SerializeField, ReadOnly] private float controlSpeed;
  
    void Start()
    {

    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {

        if (true)
        {
            transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            Debug.Log(touchPosX);
        }

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
            
        }
        else
        {
            isTouching = false;
        }
    }
}
