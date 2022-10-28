using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 1;
    public float maxY = 10;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime);

        if(this.transform.position.y > maxY) GameObject.Destroy(this.gameObject);
    }
}
