using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour {

    public float velocidade;
    public float velocidade_pulo;
 

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        // Para a direita

        if (Input.GetKey(KeyCode.A)) {

            transform.Translate(0, velocidade, 0);

        }

        // Para Esquerda

        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(0, -velocidade, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           // transform.Translate(0, 0, velocidade_pulo);
        }

    }
}
