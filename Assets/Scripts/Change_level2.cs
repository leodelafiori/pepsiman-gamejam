using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_level2 : MonoBehaviour
{


    [SerializeField] private Transform player;
    public GameObject Destruir_player;


    // quando acertar o portal
    void OnTriggerEnter(Collider other)
    {
        Destroy(Destruir_player);
        StartCoroutine("Wait");

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
}
