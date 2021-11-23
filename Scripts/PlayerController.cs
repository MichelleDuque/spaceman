using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables  del movimiento del personaje
    public float jumpForce = 6f;
    public float runningSpeed = 2f;
    Rigidbody2D rigidBody;
    Animator animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());

        //Dibujar linea desde la posicion inicial del personaje
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.red);
    }

    private void FixedUpdate() // un update que funciona a ritmo fijo, que no se retraza y no acelera 
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (Input.GetKey(KeyCode.RightArrow)) //Movimiento del personaje
            {
                rigidBody.velocity = new Vector2(runningSpeed, // eje x
                                                rigidBody.velocity.y // eje y
                                                );
                transform.localScale = new Vector2(1f, 1f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidBody.velocity = new Vector2(runningSpeed * -1, rigidBody.velocity.y);

                transform.localScale = new Vector2(-1f, 1f);

            }
        }
        else // si no estamos dentro de la partida
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);

        }
    }


    //Activar saltar
    void Jump()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (IsTouchingTheGround())
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }


    //Nos indica si el personaje esta o no el suelo
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
