using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject pauseMenu;
    public float mouseSens = 2.5f;
    public enum GameState
    {
        inMenus, inGame, paused, gameOver
    }
    public static GameState gameState;
    // Use this for initialization
    void Start()
    {
        gameState = GameController.GameState.inGame;
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CheckInput(); //check Player Input

    }
    void CheckInput()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //Open Pause Menu
        {
            pauseMenu.SetActive(true);
            gameState = GameController.GameState.paused;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void resumeGame() //close Pause Menu
    {
        gameState = GameController.GameState.inGame;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void SetSensivity(float sens) //set sens pegel
    {
        mouseSens = sens;
    }
}
