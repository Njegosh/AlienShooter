using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour {
    public TextMeshProUGUI scoreLabel;
    public List<Enemy> enemies;

    [SerializeField]
    public List<Wave> waves;

    public int currentEnemies;
    public int deadEnemies = 0;
    public int waveNumber = 0;

    bool canSpawn = false;
    public int score = 0; // Ovo ce se pomeriti negde kad se bude napravio player koji pamti igraca sa imenom i scorom
    // Start is called before the first frame update
    void Start() {
    }


    void Spawn() {
        if (canSpawn) {
            Debug.Log("Wave: " + waveNumber);

            Wave w = waves[waveNumber];
            currentEnemies = w.enemies.Count;

            foreach (EnemyPos enPos in w.enemies) {
                Enemy en = Instantiate(enPos.enemy, enPos.toWorldPos(), Quaternion.identity);
                en.moveOffset = enPos.offset;
                en.death.AddListener(() => {
                    score += en.points;
                    deadEnemies++;
                    writeScore();

                    if (deadEnemies == currentEnemies) {
                        deadEnemies = 0;
                        waveNumber = (waveNumber + 1) % waves.Count; // Za sada je ovo da se loopuju, kasnije ce biti i leveli i shopovi izmedju nekih delova
                        Spawn();
                    }
                });
            }
        }
    }

    void writeScore() {
        scoreLabel.text = score.ToString();
        Debug.Log("Score: " + score);
    }

    // Update is called once per frame

    public void StartGame() {
        EveryoneDies();
        canSpawn = true;

        waveNumber = 0;
        Spawn();
        score = 0;
        writeScore();
    }

    public void EndGame() {
        canSpawn=false;
        Invoke("EveryoneDies", 3);
    }
    public void QuickEndGame() {
        canSpawn=false;
        Invoke("EveryoneDies", 0);
    }


    void EveryoneDies() {
        try {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject e in enemies) {
                e.gameObject.TryGetComponent<Enemy>(out Enemy ee);
                ee.DieQuick();
            }
            CancelInvoke("EveryoneDies");
        } catch (UnityException e) {
            throw e;
        }
    }


    void Update() {

    }
}
