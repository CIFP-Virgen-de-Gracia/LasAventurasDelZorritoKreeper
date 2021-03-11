using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{

    public Vector3 areaAtaque;
    public float rangoAtaque = 1f;
	public LayerMask Layout;
	public Transform jugador;

	public bool girado = false;

	//Método que cambia la z al jefe 
	public void MirarAlJugador()
	{
		Vector3 girar = transform.localScale;
		girar.z *= -1f;

		if (transform.position.x > jugador.position.x && girado)
		{
			transform.localScale = girar;
			transform.Rotate(0f, 180f, 0f);
			girado = false;
		}
		else if (transform.position.x < jugador.position.x && !girado)
		{
			transform.localScale = girar;
			transform.Rotate(0f, 180f, 0f);
			girado = true;
		}
	}

	//Método que se llama en la animación de ataque del jefe y si colisionan los box collider se llama al método daño de la clase personaje
    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * areaAtaque.x;
		pos += transform.up * areaAtaque.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, rangoAtaque, Layout);
		if (colInfo != null)
		{
			colInfo.GetComponent<Personaje>().daño();
		}
	}

}
