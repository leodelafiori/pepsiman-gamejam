using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coleta_Coin : MonoBehaviour {

    public float velocidade_moeda;
 


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        transform.Rotate(-velocidade_moeda, 0, 0);
    }

    void OnTriggerEnter(Collider other) {

        
        Destroy(gameObject);

    }

}
