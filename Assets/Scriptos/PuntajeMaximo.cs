using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuntajeMaximo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI puntajeRecord;

    // Start is called before the first frame update
    void Start()
    {
        puntajeRecord = GetComponent<TextMeshProUGUI>();
        puntajeRecord.text = PlayerPrefs.GetInt("PuntajeMaximo").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
