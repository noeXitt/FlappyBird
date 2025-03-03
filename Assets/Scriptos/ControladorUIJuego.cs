using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorUIJuego : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoPuntos;
    [SerializeField] TextMeshProUGUI textoPuntosRecord;

    private void OnEnable()
    {
        ControladorPuntos.Instance.PuntajeActualizadoEVENTO += ActualizarTextoPuntaje;
    }

    private void OnDisable()
    {
        ControladorPuntos.Instance.PuntajeActualizadoEVENTO -= ActualizarTextoPuntaje;
    }


    public void ActualizarTextoPuntaje(int puntaje)
    {
        textoPuntos.text = puntaje.ToString();
    }

    

}
