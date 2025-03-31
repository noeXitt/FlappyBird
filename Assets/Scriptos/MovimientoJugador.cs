using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public float fuerzaSalto;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        anim.SetTrigger("Jumping");
        Debug.Log("Click");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AdministradorJuego.Instance.FinishGame();
    }

}        
