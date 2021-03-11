using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosGiratorios : MonoBehaviour
{

    public float velocidadGiro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Se va cambiando constantemente el eje z para darle efecto de giro
        transform.Rotate(new Vector3(0f, 0f, 20f) * (Time.deltaTime * velocidadGiro));
    }
}
