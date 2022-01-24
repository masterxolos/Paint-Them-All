using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    //[SerializeField] PlayerManager playerManager;
    [SerializeField] Transform camTransform;
    [SerializeField] int movementTime;


    //private CollectedObjController CollectedObjScript;

    public Transform target;
    [SerializeField, ReadOnly] private Vector3 offset;

    [SerializeField] float smoothSpeed;
    

    

    void LateUpdate()
    {
        
       
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, smoothedPos.z);
    }
}