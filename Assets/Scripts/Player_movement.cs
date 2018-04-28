using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour {

    public Rigidbody rb;
    public LayerMask groundLayers;
    public float jumpForce;
    public SphereCollider col;
    public float velocidade;
       
 

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        
        // Para a direita

        if (Input.GetKey(KeyCode.A)) {
                        
            transform.Translate(0, velocidade, 0);

        }

        // Para Esquerda

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, -velocidade, 0);

        }


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }

    private bool IsGrounded()
        {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
             }

}


