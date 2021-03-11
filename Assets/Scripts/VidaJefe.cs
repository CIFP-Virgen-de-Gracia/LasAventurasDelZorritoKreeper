using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJefe : MonoBehaviour
{
    public Animator animator;
    public GameObject bloqueSala;
    private int vida = 5;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //Le damos a la barra el valor de la vida
        slider.value = vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        //Cuando colisionos con el personaje
        if(_col.gameObject.tag == "Personaje")
        {
            //Se le quita una vida y se pinta en la barra
            vida --;
            slider.value = vida;

            //Si tiene entre 1 y 5 vidas salta la animación de daño
            if(vida >= 1 && vida <= 5){

                animator.SetBool("Golpe", true);

            //Si no salta la animación de muerte
            } else {
                
                animator.SetBool("Muerte", true);
                  Invoke("muerte", 0.7f);

            }
            
           
            
        }
    }

    //Método que destruye al personaje y el bloque de la sala
    private void muerte(){

        Destroy(gameObject, 0.1f);
        bloqueSala.gameObject.SetActive(false);
        Destroy(bloqueSala.gameObject, 0.5f);
        
       
    }
}
