using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour {


    //Declarando variaveis mobile
    public Swipe swipeControls;

    public Rigidbody rb;
    // Variaveis para pulo do jogador
    public LayerMask groundlayers;
    public float jumpForce;
    public SphereCollider col; 
    public float velocidade;
    public float velocidade_const;
    public Button pulo;


    // Use this for initialization
    void Start () {

        //pegando o botao pra click com pulo em android
        Button click = pulo.GetComponent<Button>();
        pulo.onClick.AddListener(botao_click);
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
            transform.Translate(0, -velocidade, 0);
        }


        // Para Esquerda

        if (Input.GetKeyDown(KeyCode.D) || swipeControls.swipeRight)
        {
            transform.Translate(0, velocidade, 0);
        }


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }


    }

    private void botao_click()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
        {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundlayers);
             }

}


