using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    //GameObject del personaje
    public GameObject personaje;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cogemos la posición en "x" y en "y" del personaje 
        float personajeX = personaje.transform.position.x;
        float personajeY = personaje.transform.position.y;
        
        //La cámara se mueve donde el personaje vaya
        transform.position = new Vector3(personajeX, personajeY, transform.position.z);
    }
}
