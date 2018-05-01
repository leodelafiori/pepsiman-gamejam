using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour {

    //teste
    int contador;

    //Declarando variaveis mobile
    public Swipe swipeControls;

    public Rigidbody rb;
    // Variaveis para pulo do jogador
    public LayerMask groundlayers;
    public float jumpForce;
    public SphereCollider col; 
    public float velocidade;
    public float velocidade_const;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>(); 
        col = GetComponent<SphereCollider>();
        
	}

    // Update is called once per frame
    void Update() {
 

        //Movimentos continuos do player
        transform.Translate(velocidade_const * Time.deltaTime, 0, 0);


        // Para a direita

        if (Input.GetKeyDown(KeyCode.A) || swipeControls.swipeLeft)
        {
            StartCoroutine("Delay_Animacao_esquerda");
        }


        // Para Esquerda

        if (Input.GetKeyDown(KeyCode.D) || swipeControls.swipeRight)
        {
            StartCoroutine("Delay_Animacao_direita");
        }


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) || IsGrounded() && swipeControls.swipeUp)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }


    }

    IEnumerator Delay_Animacao_esquerda()
    {

        for(contador = 0; contador < 6; contador++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, -0.5f, 0);
        }


    }


    IEnumerator Delay_Animacao_direita()
    {

        for (contador = 0; contador < 6; contador++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.5f, 0);
        }


    }

    private bool IsGrounded()
        {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundlayers);
             }

}


