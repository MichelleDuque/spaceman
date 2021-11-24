using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    private PlayerController controller;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            GameOver();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            BackToMenu();
        }
    }

    //metodo para iniciar el juego
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    //metodo para finalizar el juego
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    //metodo para volver al menu del juego
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO: Colocar la lógica del menu
        }
        else if (newGameState == GameState.inGame)
        {
            //TODO: Colocar la escena para jugar   
            controller.StartGame();
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: Prepara el juego para el game over
        }

        this.currentGameState = newGameState;
    }
}
