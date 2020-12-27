using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Salud))]
[RequireComponent (typeof(InputEnemigo))]
public class EnemigoIA : Enemigo
{
  private int correrHash;
  private int atacarHash;
  private int muerteHash;
  
  protected InputEnemigo input;
  private bool muerto;
  private Atacante atacante;
  private bool atacando;
  private bool enCombate;
  protected SpriteRenderer spriteRenderer;
  private Animator animator;

  private Vector2 direccionAtaque;
[SerializeField] private float distanciaDeteccion;
[SerializeField] private float distanciaAtaque;
  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    input = GetComponent<InputEnemigo>();
    atacante = GetComponent<Atacante>();
    animator = GetComponent<Animator>();
    PresentarseDeFormaCortez();
    correrHash = Animator.StringToHash("corriendo");
    atacarHash = Animator.StringToHash("atacar");
    muerteHash = Animator.StringToHash("muerto");
  }
  private void Update()
  {
    transform.position += (Vector3)input.direccionHaciaJugador*atributos.velocidad * Time.deltaTime;
    Comportamiento();

  }

  protected void Comportamiento(){
    //ataque
    if(!muerto){
      if (!atacando && input.distanciaJugador<distanciaAtaque ){
        RealizarAtaque();
      }else if(!atacando && (enCombate || input.distanciaJugador<distanciaDeteccion)){
        MoverHaciaJugador();
      }

    }


  }

  void MoverHaciaJugador(){
    animator.SetBool(correrHash,true);
    VoltearSprite();
    transform.position += (Vector3)input.direccionHaciaJugador*atributos.velocidad*Time.deltaTime;
  }
  public virtual void EnemigoAtacar(){
    atacante.Atacar(direccionAtaque ,atributos.ataque);
    atacando = false;
  }

  public virtual void VoltearSprite(){
    if (input.horizontal<0){
      spriteRenderer.flipX = true;
    }else{
        spriteRenderer.flipX = false;
    }
  }
  void SetAtacandoFalse(){
    atacando=false;
  }
  void RealizarAtaque(){
    int probabilidadDeAtaque = Random.Range(0, 100);
    if(probabilidadDeAtaque>50){
      direccionAtaque = input.direccionHaciaJugador;
      atacando = true;
      enCombate =true;
      animator.SetBool(correrHash,false);
      animator.SetTrigger(atacarHash);
    }
  }

  public void Morir(){
    muerto = true;
    animator.SetBool(muerteHash,true);
  }
}
