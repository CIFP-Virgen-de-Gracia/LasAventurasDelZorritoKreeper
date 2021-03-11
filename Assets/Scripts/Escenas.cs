using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    //Metodo que carga la escena del menu
    public void cargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //Metodo que carga la escena de la historia
    public void cargarHistoria()
    {
        SceneManager.LoadScene("Historia");
    }


    //Metodo que carga la escena de créditos
    public void cargarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }


    //Metodo que carga la escena del primer nivel
    public void cargarPrimerNivel()
    {
        SceneManager.LoadScene("PrimerNivel");
    }

    //Metodo que carga la escena del segundo nivel
    public void cargarSegundoNivel()
    {
        SceneManager.LoadScene("SegundoNivel");
    }

    //Metodo que carga la escena del tercer nivel
    public void cargarTercerNivel()
    {
        SceneManager.LoadScene("TercerNivel");
    }
}
