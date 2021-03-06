using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject Simon;
    public bool startingLevel;
    private Vector2 obj;
    private string nameLevel;
    public GameObject canvas;
    public GameObject controls;
    public bool pause;
    

    private void Start()
    {
        Simon = GameObject.Find("Ghost");
        startingLevel = false;
        pause = false;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("NPC").Length == 0 && GameObject.FindGameObjectsWithTag("Exorcist").Length == 0 &&
            (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" ||
            SceneManager.GetActiveScene().name == "Level 3"))
        {
            SceneManager.LoadScene("Win");
        }

        if (Input.GetKeyDown(KeyCode.P) &&
            (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" ||
            SceneManager.GetActiveScene().name == "Level 3"))
        {
            if (canvas.activeSelf)
            {
                controls.SetActive(false);
                canvas.SetActive(false);
                pause = false;
            }
            else
            {
                canvas.SetActive(true);
                pause = true;
            }
        }

        if (startingLevel)
        {
            if (SceneManager.GetActiveScene().name == "Story")
            {
                Simon.transform.position = Vector2.MoveTowards(Simon.transform.position, obj, 1.5f * Time.deltaTime);
                if (Vector2.Distance(Simon.transform.position, obj) < 0.01f)
                {
                    startingLevel = false;
                    SceneManager.LoadScene(nameLevel);
                }
            }
            else
            {
                startingLevel = false;
                SceneManager.LoadScene(nameLevel);
            }

            
        }
    }

    public void Unpause()
    {
        pause = false;
    }

    public void StartLevel1()
    {
        obj = new Vector2(-5.4f, 0);
        nameLevel = "Level 1";
        startingLevel = true;
    }

    public void StartLevel2()
    {
        obj = new Vector2(-3.1f, -1.2f);
        nameLevel = "Level 2";
        startingLevel = true;
    }

    public void StartLevel3()
    {
        obj = new Vector2(-1.5f, -2);
        nameLevel = "Level 3";
        startingLevel = true;
    }


    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToStreet()
    {
        SceneManager.LoadScene("Story");
    }


    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }


    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }


    public void ExitApp()
    {
        Application.Quit();
    }
}
