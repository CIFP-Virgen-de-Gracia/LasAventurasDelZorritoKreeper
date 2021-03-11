using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losas : MonoBehaviour
{

    public Transform target;
    public float velocidadMovimiento;

    private Vector3 start, end;

    private bool cambio;
   

    // Start is called before the first frame update
    void Start()
    {
        
        cambio = false;
        //el target deja de ser hijo del padre
       if(target != null)
       {
           target.parent = null;
           //en start se guarda la posición de la losa y en end la del hijo
           start = transform.position;
           end = target.position;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }

    void FixedUpdate(){

        
        if(target != null)
        {
            //Se guarda la velocidad que va a llevar la losa y mueve hacia el objetivo
            float fixedSpeed = velocidadMovimiento * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if(transform.position == target.position && cambio == false)
        {
            //Se intercambian el start por el end
            cambio = true;
            Invoke("volver", 1.5f);
            target.position = (target.position == start) ? end : start;
            
        }
      
    }

    private void volver(){
       cambio = false;
    }
}

