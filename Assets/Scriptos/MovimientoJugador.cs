using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody2D rigid;
    public float fuerzaSalto;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    rigid.velocity = new Vector2(0, fuerzaSalto);
        //}

    }

    public void Saltar()
    {
        rigid.velocity = new Vector2(0, fuerzaSalto);
        Debug.Log("Click");
    }

}        
