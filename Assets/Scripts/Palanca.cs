using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{


    public GameObject desaparecer;

    public Animator animator;

    public GameObject bloque;
    public Sprite palanca;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //Le damos valor al rigid body con el rigid body del bloque
        rb = bloque.GetComponent<Rigidbody2D>();//Recogemos el rigitbody de la plataforma

    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando la toca el personaje
        if (collision.gameObject.tag =="Personaje")
        {
           
            //Se cambia el sprite de la palanca
            gameObject.GetComponent<SpriteRenderer>().sprite = palanca;
            //Hacemos que se congele la posicion del bloque en x por lo que se descongela en la posición "y" y este cae
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            //LLamamos al método caer
            Invoke("caer", 0.5f);


            //Hacemos que el bloque de debajo del jefe caiga
            desaparecer.gameObject.SetActive(false);
            Destroy(desaparecer.gameObject, 0.5f);

            //LLamamos a intro
            Invoke("intro", 0.5f);
           
        }
       
    }

    private void caer()
    {
        //Tras 0.5 segundos congelamos el bloque en xy y destruimos la palanca
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject, 0.1f);
        Invoke("caer", 0.5f);
    }

    private void intro(){
        //Le cambiamos la animación al jefe para que pase al estado de intro
        animator.SetBool("Intro", true);
    }

}
