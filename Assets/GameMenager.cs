using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{

    public GameObject startScreen;
    public GameObject pauseScreen;

    public GameObject gameOver;

    public GameObject PlayerPrefab;

    public Spawner spawner;

    // Start is called before the first frame update
    bool game = false;

    //ako maja ovo cita, cao majo!!!! <3

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            PauseGame();
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameOver.SetActive(false);

        Instantiate(PlayerPrefab, new Vector3(0, -2), Quaternion.identity);
        spawner.StartGame();

        game = true;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        spawner.EndGame();
        game = false;
    }

    public void PauseGame()
    {
        if (game)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        startScreen.SetActive(true);

        pauseScreen.SetActive(false);
        Time.timeScale = 1;

        try
        {
            GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
            GameObject.Destroy(pl[0]);
        }
        catch (UnityException e)
        {
            throw e;
        }

        spawner.QuickEndGame();

        game = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
