using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour

{
  public string scene="Nivel_1";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CambiarScena(string sceneBuildIndex){
      SceneManager.LoadScene(sceneBuildIndex,LoadSceneMode.Single);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "Player")
      {
        SceneManager.LoadScene(scene,LoadSceneMode.Single);
      }
    }

}
