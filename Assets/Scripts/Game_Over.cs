using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

    [SerializeField] private Transform respawn;
    [SerializeField] private Transform player;
    private GameObject Destruir_player;

    // quando acertar o chao ativa esta funcao
    void OnTriggerEnter(Collider other)
    {
        //GameObject = GameObject.find(Destruir_player);
        Destroy(Destruir_player);
        StartCoroutine("Wait");
        //player.transform.position = respawn.transform.position;
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
