using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMoviles : MonoBehaviour
{
    public Transform target;
    public float velocidadMovimiento;

    private Vector3 start, end;
   

    // Start is called before the first frame update
    void Start()
    {
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

        if(transform.position == target.position)
        {
            //Se intercambian el start por el end
            target.position = (target.position == start) ? end : start;
        }
      
    }
}

