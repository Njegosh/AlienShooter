using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    AudioSource aud;
    // Start is called before the first frame update
    void Start() {
        aud = this.GetComponent<AudioSource>();
    }


    int hp = 3;

    public float speed;
    public float maxX;
    public float maxY;


    public GameObject bullet;
    public Transform topL;
    public Transform topR;

    public float bulletTime = 0.2f;

    float x, y;
    float bt = 0;

    bool shotLR;
    // Update is called once per frame
    void Update() {
        Move();
        Shoot();
    }

    void Move() {
        x = this.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        y = this.transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if (x > maxX) x = maxX;
        if (x < -maxX) x = -maxX;
        if (y > maxY) y = maxY;
        if (y < -maxY) y = -maxY;

        this.transform.position = new Vector3(x, y);
    }

    void Shoot() {
        if (bt <= bulletTime) {
            bt += 1 * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.Space)) {
            //if(shotLR)
            Instantiate(bullet, topL.position, Quaternion.identity);
            //else
            Instantiate(bullet, topR.position, Quaternion.identity);

            //shotLR = !shotLR;

            bt = 0;

            aud.PlayOneShot(aud.clip);

        }
    }

    public void Dmg() {
        hp--;

        Debug.Log("OUCH");

        if(hp<=0){
            GameObject.Destroy(this.gameObject);
        }
    }
}
