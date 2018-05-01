using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Y : MonoBehaviour {

    private GameObject player;


    //start para setar a variavel player
    private void Start()
    {
        player = GameObject.Find("Player_posicao");
    }

    //Funcao update pra checar se o player caiu do nivel pelo eixo Y
    
    private void Update()
    {

        //Tela Game-Over player
        if (player.transform.position.z > 5)
        {
            Destroy(player);
            StartCoroutine("wait");
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
