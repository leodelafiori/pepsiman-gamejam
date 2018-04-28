using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

    [SerializeField] private Transform respawn;
    [SerializeField] private Transform player;

    // quando acertar o chao ativa esta funcao
    void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene("main", LoadSceneMode.Single);

        //player.transform.position = respawn.transform.position;
        
    }
}
