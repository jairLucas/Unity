using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Atributos atributos;
    public string nombre;
    public int experiencia;

    protected void PresentarseDeFormaCortez()
    {
      Debug.Log("hola yo soy "+nombre);
    }

}
