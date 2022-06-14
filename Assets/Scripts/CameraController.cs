using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform vehiclePos;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - vehiclePos.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = vehiclePos.position + offset;
        
    }
}
