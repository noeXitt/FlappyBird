using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] float horizontalMovement; //Float que recibe el Input.GetAxis (-1 a 1)
    [SerializeField] bool movimiento; //booleano que valida si se está moviendo el personaje
    bool saltoActivado;

    [SerializeField] bool touchingGround; //booleano que valida si está tocando el piso


    Rigidbody2D rb;
    Animator anim;

    [SerializeField] Transform pivoteZonaDeteccion;
    [SerializeField] float radioZonaDeteccion;
    [SerializeField] LayerMask capasZonaDeteccion;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        ObtenerInputs();
        FlipCharacter();
    }

    private void FixedUpdate()
    {
        //Fisicas

        //Si presiona W/A/<-/-> HORIZONTAL MOVEMENT
        if (horizontalMovement != 0)
        {
            rb.velocity = new Vector2(horizontalMovement * playerSpeed,rb.velocity.y);
        }


        // JUMP
        if (saltoActivado == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            saltoActivado = false;

        }
        
        
        anim.SetFloat("VelocidadY", rb.velocity.y);

        
        //Obtenemos el Collider2D y lo pasamos a Booleano (true/false) según lo que colisione
        //1er Parametro: Zona de deteccion, 2do Parametro: Radio (float), 3er Parametro: LayerMask
        touchingGround = Physics2D.OverlapCircle(pivoteZonaDeteccion.position, radioZonaDeteccion, capasZonaDeteccion);
        //Llamo al parametro 
        anim.SetBool("TocandoPiso", touchingGround);
    }

    //Obtener los inputs que está presionando el usuario
    public void ObtenerInputs()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        movimiento = horizontalMovement != 0 ? true : false;

        //Llamo al parametro movimiento del animator y le paso la variable booleana de Movimiento, que tendra VERDADERO o FALSO
        anim.SetBool("Movimiento", movimiento);
        

        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            saltoActivado = true;
        }

    }


    //Girar al personaje
    public void FlipCharacter()
    {
        if (horizontalMovement > 0 && transform.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalMovement < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pivoteZonaDeteccion.position, radioZonaDeteccion);
    }

}
