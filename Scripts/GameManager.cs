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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //metodo para iniciar el juego
    public void StartGame()
    {

    }

    //metodo para finalizar el juego
    public void GameOver()
    {

    }

    //metodo para volver al menu del juego
    public void BackToMenu()
    {

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
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: Prepara el juego para el game over
        }

        this.currentGameState = newGameState;
    }
}
