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
        Cursor.visible = false;
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
        gameOver.GetComponent<FocusThis>().Focus();
        spawner.EndGame();
        game = false;
    }

    public void PauseGame()
    {
        if (game)
        {
            pauseScreen.SetActive(true);
            pauseScreen.GetComponent<FocusThis>().Focus();
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
        startScreen.GetComponent<FocusThis>().Focus();

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
