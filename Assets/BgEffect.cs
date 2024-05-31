using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgEffect : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    void Start()
    {
        x = this.transform.position.x;
    }

    public float bgSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(x, this.transform.position.y - bgSpeed * Time.deltaTime);
        if(this.transform.position.y<=10) this.transform.position = new Vector3(x, this.transform.position.y + 10);
    }
}
