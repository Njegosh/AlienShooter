using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<Enemy> enemies;

    [SerializeField]
    public List<Wave> waves;

    public int currentEnemies;
    public int deadEnemies=0;
    public int waveNumber=0;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void changeBr(){
        deadEnemies++;

        if(deadEnemies == currentEnemies){
            deadEnemies = 0;
            waveNumber = (waveNumber+1) % waves.Count; // Za sada je ovo da se loopuju, kasnije ce biti i leveli i shopovi izmedju nekih delova
            Spawn();
        }
    }

    void Spawn(){
        Debug.Log("Wave: " + waveNumber);

        Wave w = waves[waveNumber];
        currentEnemies = w.enemies.Count;

        foreach (EnemyPos enPos in w.enemies)
        {
            Enemy en = Instantiate(enPos.enemy, enPos.toWorldPos(), Quaternion.identity);
            en.moveOffset = enPos.offset;
            en.death.AddListener(changeBr);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
