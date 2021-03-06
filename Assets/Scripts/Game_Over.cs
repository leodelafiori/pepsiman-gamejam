﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

   
    private GameObject player;


    //start para setar a variavel player
    private void Start()
    {
        player = GameObject.Find("Player_posicao");
    }



    // quando acertar a parede ativa esta funcao
    void OnTriggerEnter(Collider other)
    {

        player = GameObject.Find("Player_posicao");
        Destroy(player);
        StartCoroutine("Wait");
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
