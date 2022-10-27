using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed;
    public float maxX;
    public float maxY;

    float x,y;
    // Update is called once per frame
    void Update()
    {

        x = this.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        y = this.transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;
        this.transform.position = new Vector3( x, y);
        if(this.transform.position.x >= maxX) this.transform.position = new Vector3(maxX, y);
        if(this.transform.position.x <= -maxX) this.transform.position = new Vector3(-maxX, y);
        if(this.transform.position.y >= maxY) this.transform.position = new Vector3(x, maxY);
        if(this.transform.position.y <= -maxY) this.transform.position = new Vector3(x, -maxY);

    }
}
