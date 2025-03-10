using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    float horizontalMovement;

    Rigidbody2D rb;

    [SerializeField] Transform pivoteZonaDeteccion;
    [SerializeField] float radioZonaDeteccion;
    [SerializeField] LayerMask capasZonaDeteccion;

    bool touchingGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        ObtenerInputs();

    }

    private void FixedUpdate()
    {
        //Fisicas

        //Si presiona W/A/<-/->
        if (horizontalMovement != 0)
        {
            rb.velocity = new Vector2(horizontalMovement * playerSpeed,rb.velocity.y);
        }


        
        
        
        //Obtenemos el Collider2D y lo pasamos a Booleano (true/false) según lo que colisione
        //1er Parametro: Zona de deteccion, 2do Parametro: Radio (float), 3er Parametro: LayerMask
        touchingGround = Physics2D.OverlapCircle(pivoteZonaDeteccion.position, radioZonaDeteccion, capasZonaDeteccion);

    }

    public void ObtenerInputs()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pivoteZonaDeteccion.position, radioZonaDeteccion);
    }

}
