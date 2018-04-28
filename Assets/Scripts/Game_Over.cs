using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over : MonoBehaviour {

    [SerializeField] private Transform respawn;
    [SerializeField] private Transform player;

    // quando acertar o chao ativa esta funcao
    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawn.transform.position;
        
    }
}
