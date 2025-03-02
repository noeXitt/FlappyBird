using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego Instance;

    public delegate void EstadosJuegoDelegado();
    public EstadosJuegoDelegado startGameEvent;
    public EstadosJuegoDelegado pauseGameEvent;
    public EstadosJuegoDelegado continueGameEvent;
    public EstadosJuegoDelegado gameOverEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Time.timeScale = 0;

    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startGameEvent?.Invoke(); //El simbolo de interrogacion valida que Al menos UNA Funcion este suscrita
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseGameEvent?.Invoke(); //El simbolo de interrogacion valida que Al menos UNA Funcion este suscrita
        
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
       continueGameEvent?.Invoke();
        
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        gameOverEvent?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("LEVEL RESTARTED");
    }

    public void ExitGame()
    {
        Debug.Log("EXIT GAME log");
        Application.Quit();

    }

}
