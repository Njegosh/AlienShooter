using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    AudioSource aud;

    public GameObject regularSprite;
    
    public List<GameObject> hearts;

    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        gameMenager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMenager>();
        aud = this.GetComponent<AudioSource>();
        
        hearts.Add(GameObject.Find("h1"));
        hearts.Add(GameObject.Find("h2"));
        hearts.Add(GameObject.Find("h3"));

        foreach (GameObject h in hearts)
        {
            h.GetComponent<HeartUI>().Reset();
        }
            
    }

    public GameMenager gameMenager;
    int hp = 3;

    public float speed;
    public float maxX;
    public float maxY;

    

    public GameObject bullet;
    public Transform topL;
    public Transform topR;
    public float stickMove;

    public float bulletTime = 0.2f;

    float x, y;
    float bt = 0;

    bool canShoot = true;

    bool shotLR;
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

    void Shoot()
    {
        if(canShoot){
            if (bt <= bulletTime)
            {
                bt += 1 * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                //if(shotLR)
                Instantiate(bullet, topL.position, Quaternion.identity);
                //else
                Instantiate(bullet, topR.position, Quaternion.identity);

                //shotLR = !shotLR;

                bt = 0;

                aud.PlayOneShot(aud.clip);

            }
        }
    }

    public bool immune;
    int flashes = 0;
    public void Dmg()
    {
        if (!immune)
        {
            
            hp--;
            
            hearts[hp].GetComponent<HeartUI>().HpDown();

            canShoot=false;
            immune = true;
            IEnumerator coroutine = Flashing();
            StartCoroutine(coroutine);


            if (hp <= 0)
            {
                gameMenager.GameOver();
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator Flashing()
    {
        LTSeq seq = LeanTween.sequence();

        seq.append(() => { LeanTween.color(regularSprite, new Color(0, 0, 0, 0), 0.01f); });
        yield return new WaitForSeconds(0.05f);

        while (flashes <= 5)
        {
            
            seq.append(() => { LeanTween.color(regularSprite, new Color(0, 0, 0, 0), 0.01f); });
            yield return new WaitForSeconds(0.1f);
            seq.append(() => { LeanTween.color(regularSprite, Color.white, 0.02f); });
            yield return new WaitForSeconds(0.05f);

            flashes += 1;

            if(flashes>1)
                canShoot=true;

        }

        seq.append(() => { LeanTween.color(regularSprite, new Color(0, 0, 0, 0), 0.01f); });
        yield return new WaitForSeconds(0.5f);
        seq.append(() => { LeanTween.color(regularSprite, Color.white, 0.25f); });
        yield return new WaitForSeconds(0.25f);

        flashes = 0;
        immune = false;
    }
}
