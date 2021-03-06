﻿using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {

    //Las variables publicas sirven para poder modificarlas desde el inspector
    //Prevalece lo que pongamos en el inspector
    public float gravedad = -7f;
    public float fuerzaSalto = 3f;
    private bool movimiento = false;
    public float velocidad = 10f;
    //cantidad de puntos para aumentar la velocidad
    public int limiteAumentoVelocidad = 10;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start () {
      
    }

    //FixedUpdate se usa con RigidBody
    //Update se llama una vez por frame pero el tiempo entre frame puede variar. UN frame puede tardar mas en generarse.
    //FixedUpdate tiene el mismo tiempo entre llamadas
    void FixedUpdate() {

        if (movimiento){
            //cuando se empieza a mover la gravedad se activa(animacion quieta)
            Physics2D.gravity = new Vector2(0, gravedad);

            //Controla la velocidad
            //La X del vector es la variable velocidad y la de Y es la que tiene el Rigidbody del pj por si esta saltando que siga saltando
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);

        }
        else {
            //si movimiento == false no hay gravedad, animacion bonita y estrella en el aire
            Physics2D.gravity = new Vector2(0, 0);
        }
        //ACtualiza la VelX del rigidbody con la velocidad eje X actual del pj(Controla el paso de la animacion quieta a movimiento
        animator.SetFloat("VelX", GetComponent<Rigidbody2D>().velocity.x);
    }


        // Update is called once per frame
        void Update () {

        aumentoVelocidad();
        //aumentoVelocidadTiempo();

        //Input hace que sea cualquier GetMOuseDown en cualquier lugar de la pantalla(?), algo para android
        //Si el boton 0 del raton(izquierdo) se pulsa o tocamos la pantalla el personaje salta con una fuerza = fuerzaSalto
        if (Input.GetMouseButtonDown(0))
        {
            if (movimiento)
            {
                //Vector2(velocidad X del rigidbody(para que pueda saltar y desplazarse a la vez), fuerzaSalto)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
            
            }
            else
            {
                movimiento = true;
                //se notifica al notificationCenter que esta clase(el pj)  se mueve, "PersonajeEmpiezaACorrer"
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
            }
        }

	}

    //aumenta la velocidad segun se consigue mas puntuacion
    void aumentoVelocidad()
    {
        //modo normal
        for (; Puntuacion.puntuacion >= limiteAumentoVelocidad; velocidad += +1)
        {
            limiteAumentoVelocidad += 5;
        }

        //modo por tiempo
        for (; PuntuacionTiempo.puntuacionTiempo >= limiteAumentoVelocidad; velocidad += 1)
        {
            limiteAumentoVelocidad += 5;
        }

    }

    //Version antigua, por si acaso
    /* void aumentoVelocidad()
   {
       for (; Puntuacion.puntuacion >= limiteAumentoVelocidad; velocidad +=+ 1)
       {
           limiteAumentoVelocidad += 5;
       }
   }

   void aumentoVelocidadTiempo()
   {
       for (; PuntuacionTiempo.puntuacionTiempo >= limiteAumentoVelocidad; velocidad += 1)
       {
           limiteAumentoVelocidad += 5;
       }
   }*/


}
