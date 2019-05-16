using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxScale;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 prevCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        prevCamPos = cam.position;

        parallaxScale = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       for(int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (prevCamPos.x - cam.position.x) * parallaxScale[i];
            float backgroundTargetPosx = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosx, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        prevCamPos = cam.position;

    }
}
