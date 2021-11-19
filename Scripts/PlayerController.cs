using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables  del movimiento del personaje
    public float jumpForce = 6f;
    Rigidbody2D rigidBody;

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }


        //Dibujar linea desde la posicion inicial del personaje
        Debug.DrawRay(this.transform.position, Vector2.down * 1.315f, Color.red);
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    //Nos indica si el personaje esta o no el suelo
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.315f, groundMask))
        {
            //TODO: programar logica de contacto con el suelo
            return true;
        }
        else
        {
            //TODO: programar logica de no contacto
            return false;
        }
    }
}