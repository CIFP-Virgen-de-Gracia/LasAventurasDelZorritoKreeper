using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{


    public AudioClip salto;
    public AudioClip golpe;

    private AudioSource personaje_AS;

    private bool saltando;

    private int vidas;
    private int frutas;

    public Vector3 posicionInicial;

    public Animator animator;

    public bool chiquito = false;

    private bool moviendoDerecha;
    private bool moviendoIzquierda;

    public int nivel;



    public int Vidas {
    get {return vidas;}
    set{vidas = value;}
    }
    public int Fruta{
    get {return frutas;}
    set{frutas = value;}
    }

    // Start is called before the first frame update
    void Start()
    {

        //Si estamos en el nivel 2 o 3
        if(nivel == 2 || nivel == 3)
        {
            
           //Rescatamos las vidas y las frutas
           vidas = PlayerPrefs.GetInt("vidas");
           frutas = PlayerPrefs.GetInt("frutas");
        }
        else//Si no dejamos las vidas a 3 y la fruta a 0
        {
            PlayerPrefs.SetInt("chiquito", 0);
            vidas = 3;
            frutas = 0;
        }
        //Guardamos en posición inicial la posición del personaje, para cuando se caiga vuelva al principio
        posicionInicial = transform.position;
        saltando = false;
        //Asignamos el audio source
        personaje_AS = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Para que se mueva a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)|| moviendoIzquierda == true) 
        {
            //Si chiquito vale 1 hacemos el personaje mas pequeño
            //Rotamos la x del personaje
            if(PlayerPrefs.GetInt("chiquito") == 1)
            {
               transform.localScale = new Vector3(-1f, 1f, 1f);
            } else {
                transform.localScale = new Vector3(-5f, 5f, 1f);
            }

            //Lo movemos a la izquierda
            transform.Translate(new Vector3(-0.05f, 0.0f));
                      
            //activamos la animacion de correr
            animator.SetBool("Correr", true);

        } else 

        //Para que se mueva a la derecha
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)|| moviendoDerecha == true)
        {
            //Si chiquito vale 1 hacemos el personaje mas pequeño
            //Rotamos la x del personaje
            if(PlayerPrefs.GetInt("chiquito") == 1){
                transform.localScale = new Vector3(1, 1f, 1f);//Se gira hacia la derecha
            } else {
                transform.localScale = new Vector3(5, 5f, 1f);//Se gira hacia la derecha
            }

            //Lo movemos a la izquierda
            transform.Translate(new Vector3(0.05f, 0.0f));

            //activamos la animación de correr
            animator.SetBool("Correr", true);

        }else{

            //Para la animacion de correr
            animator.SetBool("Correr", false);
        }

        //Para que salte
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();                  
        }
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        //Cuando colisiona contra el suelo se pone salto a false y acaba la animación de saltar
        if(_col.gameObject.tag == "Suelo")
        {
            saltando = false;
            animator.SetBool("Saltando", saltando);
        }
        //Cuando colisiona contra trampolin nos da una fuerza que nos hace saltar
        if(_col.gameObject.tag == "Trampolin")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 1000.0f));
            animator.SetBool("Saltando", true);
        }
        //Cuando colisiona contra nube nos da una fuerza que nos hace saltar
        if(_col.gameObject.tag == "Nube")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 600.0f));
            saltando = false;
            animator.SetBool("Saltando", saltando);
        }
        //Cuando colisiona contra daño llamamos al metodo daño
        if (_col.gameObject.tag == "Daño")
        {
             daño();                   
        }
        //Cuando coliona contra volver llamos al método daño y volvemos a la posición inicial
        if(_col.gameObject.tag == "Volver")
        {
            daño();
            transform.position = posicionInicial;
        }
        //Cuando colisiona contra jefe se acaba la animacion de saltar
        if(_col.gameObject.tag == "Jefe")
        {
            saltando = false;
            animator.SetBool("Saltando", saltando);
        }
        //Cuando colisiona contra nivel2 
        if (_col.gameObject.tag == "Nivel2")
        {
            //LLamamos a vidasFrutas y cargamos el segundo nivel
            Debug.Log("Vidas: " + PlayerPrefs.GetInt("vidas"));
            Debug.Log("Frutas: " + PlayerPrefs.GetInt("frutas"));
            vidasFrutas();
            SceneManager.LoadScene("SegundoNivel");
        }
        //Cuando colisiona contra nivel3
        if (_col.gameObject.tag == "Nivel3")
        {
            //LLamamos a vidasFrutas y cargamos el tercer nivel
            vidasFrutas();
            SceneManager.LoadScene("TercerNivel");
        }
        //Cuando colisiona contra nivel3Chiquito
        if (_col.gameObject.tag == "Nivel3Chiquito")
        {
            //LLamamos a vidasFrutas y cargamos el tercer nivel dandole valor 1 a chiquito
            vidasFrutas();
            PlayerPrefs.SetInt("chiquito", 1);
            SceneManager.LoadScene("TercerNivel");
        }
        //Cuando colisiona contra creditos
        if (_col.gameObject.tag == "Creditos")
        {
            SceneManager.LoadScene("Creditos");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Cuando colisiona con una fruta, elimina la fruta y aumenta la variable fruta
        if (collision.gameObject.tag == "Fruta")
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            frutas++;/
        }
        //Cuando colisiona con daño se llama al método daño
        if (collision.gameObject.tag == "Daño")
        {
            daño();
            
        }

    }

    //Método que nos resta vida cada vez que es llamada
    public void daño()
    {
        //Sonido del daño
        personaje_AS.clip = golpe;
        personaje_AS.Play();
        
        //Resta una vida
        vidas--;
        
        //Si tiene 2 o 1 vida se activa la animación de daño, si no, la de
        if (vidas == 2 || vidas == 1)
        {
            animator.SetTrigger("Daño");

        } else {
            animator.SetTrigger("Muerte");
        } 

        //Si vidas es 0 llamamos a la escena de créditos
        if (vidas <= 0)
        {
            SceneManager.LoadScene("Creditos");       
        }
    }

    //Guardamos las vidas y frutas que llevaba en ese momento
    private void vidasFrutas()
    {
        PlayerPrefs.SetInt("vidas", vidas);
        PlayerPrefs.SetInt("frutas", frutas);
    }


    //Método que le da un impulso al personaje, activa la animacion y le mete musica 
    public void Saltar()
    {
        if(saltando == false)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
            saltando = true;
            animator.SetBool("Saltando", saltando);
            personaje_AS.clip = salto;
            personaje_AS.Play();
        }

    }

    //Pone a true moverderecha
    public void MoverDerecha(bool _activar){
        moviendoDerecha = _activar;
    }

    //Pone a true moverizquierda
    public void MoverIzquierda(bool _activar){
        moviendoIzquierda = _activar;
    }
    

}
