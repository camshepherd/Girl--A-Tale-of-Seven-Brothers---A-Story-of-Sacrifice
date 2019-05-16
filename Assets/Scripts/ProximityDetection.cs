using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetection : MonoBehaviour
{
    SpriteRenderer renderer;
    Transform other;
    public float detectDistance = 20;
    public bool permanentDetection = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        other = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,other.position) <= detectDistance)
        {
            renderer.enabled = true;
        }
        else if(!permanentDetection && Vector3.Distance(transform.position, other.position) > detectDistance)
        {
            renderer.enabled = false;
        }
    }
}
