using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float xinput, zinput = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            zinput--;
        }
        if (Input.GetKey("s"))
        {
            zinput++;
        }
        if (Input.GetKey("a"))
        {
            xinput++;
        }
        if (Input.GetKey("d"))
        {
            xinput--;
        }

        zinput *= 0.05f;
        xinput *= 0.05f;

        Vector3 currentPos = this.transform.position;
        currentPos.x += xinput;
        currentPos.z += zinput;

        //Debug.Log(Input.mouseScrollDelta.y * (this.transform.forward * -1));
        currentPos += Input.mouseScrollDelta.y * this.transform.forward;

        this.transform.position = currentPos;
        xinput = 0;
        zinput = 0;
    }
}
