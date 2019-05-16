using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float xmin, xmax, ymin, ymax;
    public float xoffset, yoffset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x + xoffset,xmin,xmax), Mathf.Clamp(player.transform.position.y + yoffset, ymin, ymax), transform.position.z);
    }
}
