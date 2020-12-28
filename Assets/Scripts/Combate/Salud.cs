using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Salud : MonoBehaviour
{
    public int saludBase;
    private int saludActual;
    public Transform barraDeSalud;
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
          else
          {
                  
    
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
     try
     {
         ActualizarBarraDeSalud(); 
     }
     catch (System.Exception)
     {
         
         throw;
     }
     
    }
    public void DestruirGameObject(){
      Destroy(gameObject,1f);
    }
    private void ActualizarBarraDeSalud(){
      try
      {
         Vector3 escala = new Vector3((float)SaludActual / saludBase,1,1);
      barraDeSalud.localScale=escala;
          
      }
      catch (System.Exception)
      {
          
          throw;
      }
     
    }
    public void Reiniciar(){
       SceneManager.LoadScene("Scenes/Nivel_1");
    }


}
