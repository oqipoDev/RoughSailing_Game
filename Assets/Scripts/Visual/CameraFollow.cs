using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Follow;
    [Range(0, 1)] public float Smoothness = 0.5f;
    //public bool LockY = false;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Follow.position;
        transform.position = Vector3.Lerp(Follow.position, transform.position, Mathf.Pow(Smoothness, 0.5f));
    }
}
