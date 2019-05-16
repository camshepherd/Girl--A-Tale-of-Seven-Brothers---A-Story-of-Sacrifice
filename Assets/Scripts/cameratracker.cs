using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratracker : MonoBehaviour
{
    public GameObject camera;
    private Transform other;

    // Start is called before the first frame update
    void Start()
    {
        other = camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(other.position.x, transform.position.y, transform.position.z);
    }
}
