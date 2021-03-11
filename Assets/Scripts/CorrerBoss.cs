using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrerBoss :  StateMachineBehaviour
{

    public float velocidad = 2.5f;
    public float rangoAtaque = 3f;

    Transform jugador;
    Rigidbody2D rb;

    Jefe jefe;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Se guarda en la variable jugador al game object con el tag "personaje"
        jugador = GameObject.FindGameObjectWithTag("Personaje").transform;
        //Asignamos a rb el rigitbody del jefe
        rb = animator.GetComponent<Rigidbody2D>();
        //Asignamos a el script jefe a la variable jefe
        jefe =  animator.GetComponent<Jefe>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Llamamos al método MirarAlJugador de la clase jefe, que lo que hace es rotar la x para que siempre lo tengas de cara
        jefe.MirarAlJugador();

        //Se guarda en target la posicion que va a seguir el jefe
        Vector2 target = new Vector2(jugador.position.x, rb.position.y);
        //Se guarda en posicion nueva, la posicion que debe seguir el jefe
        Vector2 posicionNueva = Vector2.MoveTowards(rb.position, target, velocidad * Time.fixedDeltaTime);
        //Hacemos se mueva
        rb.MovePosition(posicionNueva);

        //Si el jefe está en rago de ataque, se activa la animacion de ataque
        if (Vector2.Distance(jugador.position, rb.position) <= rangoAtaque)
        {
            animator.SetTrigger("Atacar");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Esto lo ponemos para que resetee el trigger de atacar porque si no se puede buggear
        animator.ResetTrigger("Atacar");
    }

}