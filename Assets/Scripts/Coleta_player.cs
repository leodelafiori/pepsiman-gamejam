using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coleta_player : MonoBehaviour
{
    public TextMeshProUGUI Obj_texto;
    public int pontuacao;
 
    // Use this for initialization
    void Start()
    {
       
        Obj_texto.text = pontuacao.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Obj_texto.text = pontuacao.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        pontuacao++;
    }
}
