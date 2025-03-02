using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPaneles : MonoBehaviour
{

    [SerializeField] GameObject startPanel, onGamePanel, pausePanel, gameOverPanel;

    private void OnEnable()
    {
        //Llamo directamente a la Clase, luego a su variable de tipo 'AdministradorJuego' llamada INSTANCE y llamo a su evento
        //'startGameEvent' y le suscribo '+=' la función de mostrar el panel en juego o HUD 'showOnGamePanel'

        AdministradorJuego.Instance.startGameEvent += showOnGamePanel; // el "+=" suscribe la función de este script
        AdministradorJuego.Instance.pauseGameEvent += showPauseMenuPanel;
        AdministradorJuego.Instance.continueGameEvent += showOnGamePanel;
        AdministradorJuego.Instance.gameOverEvent += showGameOverPanel;
    }

    private void OnDisable()
    {
        AdministradorJuego.Instance.startGameEvent -= showOnGamePanel; // el "+=" suscribe la función de este script
        AdministradorJuego.Instance.pauseGameEvent -=showPauseMenuPanel;
        AdministradorJuego.Instance.continueGameEvent -= showOnGamePanel;
        AdministradorJuego.Instance.gameOverEvent -= showGameOverPanel;
    }

    public void showOnGamePanel()
    {
        startPanel.SetActive(false);
        onGamePanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Debug.Log("ON GAME panel");
    }

    public void showGameOverPanel()
    {
        startPanel.SetActive(false);
        onGamePanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Debug.Log("GAME OVER panel");
    }

    public void showPauseMenuPanel()
    {

        startPanel.SetActive(false);
        onGamePanel.SetActive(false);
        pausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        Debug.Log("PAUSE MENU panel");
    }




}
