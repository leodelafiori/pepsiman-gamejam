using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

    
    [SerializeField] private Transform player;
    public GameObject Destruir_player;
    

    // quando acertar o chao ativa esta funcao
    void OnTriggerEnter(Collider other)
    {
        Destroy(Destruir_player);
        StartCoroutine("Wait");
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
