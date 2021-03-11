using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text frutas;
    public Personaje pj;
    public Image vida3, vida2, vida1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
          
        //Se pone en el txt del canvas el contador de frutas
        frutas.text = pj.Fruta.ToString();

        if(pj.Vidas == 2)//Si el personaje tiene dos vidas
        {
            //desaparece un corazón
            vida3.enabled = false;
        }

        if (pj.Vidas == 1)//Si el personaje tiene  1 vida
        {
            //desaparecen dos corazones
            vida2.enabled = false;
            vida3.enabled = false;

        }

        if (pj.Vidas == 0)//Si el personaje tiene 0 vidas
        {
            //desaparecen todos los corazones
            vida1.enabled = false;
            vida2.enabled = false;
            vida3.enabled = false;

        }
    }
}
