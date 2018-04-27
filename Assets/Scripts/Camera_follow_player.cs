using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow_player : MonoBehaviour {

    public Transform playerTransform;
    public Transform mainCameraTransform = null;
    private Vector3 cameraOffset = Vector3.zero;


	// Use this for initialization
	void Start () {

        mainCameraTransform = Camera.main.transform;

        // Pega a distancia player camera pelo camera offset subtraindo uma da outra
        cameraOffset = mainCameraTransform.position - playerTransform.position;
               

	}
	
	// Update is called once per frame
	void LateUpdate () {

        // Movendo a camera de acordo com o objeto usando o offset setado no começo
        mainCameraTransform.position = playerTransform.position + cameraOffset;

    }
}
