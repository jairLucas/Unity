using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;
    public GameObject jugador;
    // Start is called before the first frame update
    private void Start()
    {
        cv = GetComponent<CinemachineVirtualCamera>();
        Transform jugador = GameManager.instance.jugador.transform;
        cv.m_Follow = jugador;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
