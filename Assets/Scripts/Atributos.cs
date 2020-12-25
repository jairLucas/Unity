using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ObjetosScriptables/Atributos")]
public class Atributos:ScriptableObject
{
    [Tooltip("Velocidad de movimiento")]
    public int velocidad;
    public int ataque;
}
