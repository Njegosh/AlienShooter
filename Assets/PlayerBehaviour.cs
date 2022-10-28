using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float speed;
    public float maxX;
    public float maxY;


    public GameObject bullet;
    public Transform topL;
    public Transform topR;

    public float bulletTime = 0.2f;

    float x, y;
    float bt = 0;
    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        x = this.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        y = this.transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if (x > maxX) x = maxX;
        if (x < -maxX) x = -maxX;
        if (y > maxY) y = maxY;
        if (y < -maxY) y = -maxY;

        this.transform.position = new Vector3(x, y);
    }

    void Shoot(){
        if (bt <= bulletTime)
        {
            bt += 1 * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, topL.position, Quaternion.identity);
            Instantiate(bullet, topR.position, Quaternion.identity);
            bt=0;
        }

        Debug.Log("Pucanj!");
    }
}
