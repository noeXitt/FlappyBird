using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;

    public delegate void ActualizarPuntajeDELEGADO(int nuevoPuntaje);
    public ActualizarPuntajeDELEGADO PuntajeActualizadoEVENTO;


    [SerializeField] int puntosActuales = 0;


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

    public void SumarPunto()
    {
        puntosActuales++;
        PuntajeActualizadoEVENTO?.Invoke(puntosActuales);
    }


}
