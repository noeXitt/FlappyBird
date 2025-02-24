using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
public void IniciarJuego()
    {
        Time.timeScale = 1;
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1;
    }

    public void FinalizarJuego()
    {
        Time.timeScale = 0;
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

}
