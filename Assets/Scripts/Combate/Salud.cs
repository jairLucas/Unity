﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Salud : MonoBehaviour
{
    public int saludBase;
    private int saludActual;
    public UnityEvent OnMorir;
    public int SaludActual
    {
      get
      {
        return saludActual;
      }
      set
      {
        if(value>0 && value<=saludBase)
        {
          saludActual = value;
        }
        else if(value>saludBase)
        {
          saludActual = saludBase;
        }
        else
        {
          saludActual = 0;
          if (OnMorir!=null){
            OnMorir.Invoke();
          }
        }
      }
    }
    // Start is called before the first frame update
    void Start()
    {
        SaludActual = saludBase;
    }

    public void modificarSaludActual(int cantidad)
    {
      SaludActual += cantidad;
    }
    private void DestruirGameObject(){
      Destroy(gameObject);
    }


}
