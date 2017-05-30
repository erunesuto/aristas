﻿using UnityEngine;


//este script va asociado a la camara.
public class SeguirPersonaje : MonoBehaviour {
    //COntiene la informacion de posicion, rotacion etc... del objeto asignado en el inspector.
    public Transform personaje;
    //Separacion es la distancia de separacion respecto al centro de la pantalla. Separacion=0 el pj esta en el centro.
    public float separacion = 7f;

    // Update is called once per frame
    void Update () {
        //Una vez tenemos acceso a la posicion del pj igualamos la posicion de la camara a la del pj
        //la X de la camara = a la X del pj, la Y y Z de la camara son la de la camara, sigue al pj con un desplazamiento lateral unicamente
        transform.position = new Vector3(personaje.position.x + separacion, transform.position.y, transform.position.z);

    }
}
