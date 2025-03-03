using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;

    public delegate void ActualizarPuntajeDELEGADO(int nuevoPuntaje);
    public ActualizarPuntajeDELEGADO PuntajeActualizadoEVENTO;


    [SerializeField] int puntosActuales = 0;
    [SerializeField] int puntajeFinal = 0;
    [SerializeField] int puntajeMaximo = 0;

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
        puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo");
    }

    public void SumarPunto()
    {
        puntosActuales++;
        PuntajeActualizadoEVENTO?.Invoke(puntosActuales);

        puntajeFinal = puntosActuales;

        if (puntosActuales > puntajeMaximo)
        {
            puntajeMaximo = puntosActuales;
            PlayerPrefs.SetInt("PuntajeMaximo", puntajeMaximo);
        }

    }


}
