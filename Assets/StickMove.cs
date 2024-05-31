using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMove : MonoBehaviour
{    public Transform stick;
    public Transform btn;
    public float stickMove;

    Vector3 bp1, bp2;


    Material btnMat;
    void Start()
    {
        bp1 = btn.position;
        bp2 = bp1- new Vector3(0,0.2f,0);

        btnMat = btn.GetComponent<MeshRenderer>().material;
        
        btnMat.EnableKeyword("_EMISSION");
    }

    public float glowIntensity;

    // Update is called once per frame
    void Update()
    {
        Vector3 stickLookAt = new Vector3(stick.transform.position.x - Input.GetAxis("Horizontal") *stickMove, stick.transform.position.y + 2, stick.transform.position.z - Input.GetAxis("Vertical") *stickMove);

        stick.transform.LookAt(stickLookAt,Vector3.back);

        Vector3 forward = stickLookAt;
        Debug.DrawRay(stick.transform.position, stickLookAt, Color.green);


        if (Input.GetKey(KeyCode.Space))
        {
            btn.position =  bp2;
            btnMat.SetColor("_EmissionColor", btnMat.color * glowIntensity);

        }
        else{
            btn.position =  bp1;
            btnMat.SetColor("_EmissionColor", btnMat.color * 0f);
        }

    }
}
