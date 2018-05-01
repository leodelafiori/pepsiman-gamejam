using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Funcao criada apenas para fazer animacao da lata


public class Player_animacao_rotacao : MonoBehaviour {

    public float player_rotacao;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate( 0, -player_rotacao, 0);
	}
}
