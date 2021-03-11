using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasSuicidas : MonoBehaviour
{
   //Variables
    public Vector3 posInicial;
    private bool mover = false;
    public float velocidad = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;//Recogemos la posicion inicial de la plataforma
    }

    // Update is called once per frame
    void Update()
    {
        //Si mover es verdadero se mueve la plataforma para abajo
        if (mover)
        {
            transform.Translate(new Vector3(0.0f, -velocidad));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando colisiona con el personaje
        if (collision.gameObject.tag =="Personaje")
        {
            //Se llama al método caer
            Invoke("caer", 0.5f);
        }
        //Cuando toca a volver, llama al método volver
        if(collision.gameObject.tag == ("Volver"))
        {
              Invoke("volver", 3.0f);
           
        }
    }

    //Metodo que cambia mover a true
    private void caer()
    {
        mover = true;
    }

    //Método que hace que vuelva la plataforma a su posición original
    private void volver()
    {
        mover =  false;
        transform.position = posInicial;
    }

}
