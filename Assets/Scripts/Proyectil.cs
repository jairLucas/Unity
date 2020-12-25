using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Proyectil : MonoBehaviour
{
  public float velocidadInicial;
  public Vector2 direccionInicial;
  public int danio;
  public Proyectil proyectil;
  private Rigidbody2D miRigibody2d;
    // Start is called before the first frame update
    void Start()
    {
      miRigibody2d = GetComponent<Rigidbody2D>();
      miRigibody2d.velocity = direccionInicial.normalized * velocidadInicial;

    }


}
