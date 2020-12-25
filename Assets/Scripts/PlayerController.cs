using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputPlayer inputJugador;
    private Transform transformada;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer miSprite;
    public Atributos atributosJugador;
    private Atacante atacante;
    int correrHashCode;


    // Start is called before the first frame update
    void Start()
    {
        inputJugador = GetComponent<InputPlayer>();
        transformada = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        atacante = GetComponent<Atacante>();
        miSprite = GetComponent<SpriteRenderer>();
        correrHashCode = Animator.StringToHash("corriendo");

    }
    // Update is called once per frame
    void Update()
    {
        horizontal = inputJugador.ejeHorizontal;
        vertical = inputJugador.ejeVertical;

        if (vertical!=0 || horizontal!=0)
        {
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);
            animator.SetBool(correrHashCode,true);
        }else{
            animator.SetBool(correrHashCode,false);
        }
        if (Input.GetButtonDown("Atacar"))
        {
            animator.SetBool("Atacando",true);
        }
    }
    void FixedUpdate(){
      //----------------Movimiento----------------//
      if (animator.GetBool("Atacando"))
      {
        rb2d.velocity = Vector2.zero;
      }
      else
      {
        Vector2 vector_velocidad = new Vector2(horizontal,vertical)*atributosJugador.velocidad;
        rb2d.velocity = vector_velocidad;
      }

    }

    void ControllerAtacar()
    {
        atacante.Atacar(inputJugador.direccionMirada,atributosJugador.ataque);
        animator.SetBool("Atacando",false);
    }
}
