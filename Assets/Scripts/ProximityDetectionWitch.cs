using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetectionWitch : MonoBehaviour
{
    bool alreadyEnabled = false;
    Transform other;
    public float detectDistance = 20;
    bool permanentDetection = true;
    AudioSource audio;

    Vector3 offset = new Vector3(0,-50,0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position += offset;
        other = GameObject.Find("Player").GetComponent<Transform>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position - offset, other.position) <= detectDistance && !alreadyEnabled)
        {
            transform.position -= offset;
            alreadyEnabled = true;
            audio.Play();
        }
        else if (!permanentDetection && Vector3.Distance(transform.position - offset, other.position) > detectDistance)
        {
            alreadyEnabled = false;
            transform.position += offset;
        }
    }
}
