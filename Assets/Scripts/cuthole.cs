using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuthole : MonoBehaviour
{
    private bool isholding;

    void deleteTri(int index)
    {
        Destroy(this.gameObject.GetComponent<MeshCollider>());
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        int[] oldTriangles = mesh.triangles;
        int[] newTriangles = new int[mesh.triangles.Length - 3];

        int i = 0;
        int j = 0;
        while (j < mesh.triangles.Length)
        {
            if (j != index * 3)
            {
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
            }
            else
            {
                j += 3;
            }
        }

        transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
        gameObject.AddComponent<MeshCollider>();
    }

    void Update()
    {
        Ray ray = new Ray();
        ray.origin = Vector3.zero;
        float inverseResolution = 10f;
        Vector3 direction = Vector3.right;
        int steps = Mathf.FloorToInt(360f / inverseResolution);
        Quaternion xRotation = Quaternion.Euler (Vector3.right * inverseResolution);
        Quaternion yRotation = Quaternion.Euler(Vector3.up * inverseResolution);
        Quaternion zRotation = Quaternion.Euler(Vector3.forward * inverseResolution);
        for(int x=0; x < steps/2; x++) {
            direction = zRotation * direction;
            for(int y=0; y < steps; y++) {
                direction = xRotation * direction;
                Debug.DrawLine(ray.origin,ray.origin+direction); // for science
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            isholding = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isholding = false;
        }
        if(isholding){
            RaycastHit hit;
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray1, out hit, 1000.0f))
            {
                deleteTri(hit.triangleIndex);
            }
        }
    }
}
