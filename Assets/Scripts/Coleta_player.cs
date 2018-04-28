using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleta_player : MonoBehaviour
{

    public Text objetoP;
    public int pontuacao;

    // Use this for initialization
    void Start()
    {
        objetoP.text = pontuacao.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        objetoP.text = pontuacao.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        pontuacao++;
    }
}
