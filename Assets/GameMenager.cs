using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{

    public GameObject startScreen;

    public GameObject gameOver;

    public GameObject PlayerPrefab;

    public Spawner spawner;

    // Start is called before the first frame update
    bool game = false;

    //ako maja ovo cita, cao majo!!!! <3

    public void StartGame(){
        startScreen.SetActive(false);
        gameOver.SetActive(false);

        Instantiate(PlayerPrefab, new Vector3(0,-2), Quaternion.identity);
        spawner.StartGame();
    }

    public void GameOver(){
        gameOver.SetActive(true);
        spawner.EndGame();
    }

    public void Quit() {
        Application.Quit();
    }
}
