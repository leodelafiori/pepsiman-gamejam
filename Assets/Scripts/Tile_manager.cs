using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Tile_manager : MonoBehaviour {

    //Pegando os valores de arrays do prefab
    public GameObject[] tilePrefabs;

    //Pegando a posição do player ( Pra saber onde spawnar os tiles e retirar os antigos )
    public Transform playerTransform;

    //Float pra saber onde vai spawnar o item ( vai se mover sempre em X pra frente quando spawnar )
    private float spawnX = 0.0f;

    // Calculando a distancia de um tile pra outro, todos tem que ter a mesma distancia pra poder spawnar direito
    private float tilelenght = 50.0f;

    //int pra ver quantidade de tiles que vai ficar na tela
    private int amnTilesOnScreen = 7;

    // Declarando uma lista ( possivel pelo system collection generic acima ) pra reconhecer os tiles que ficaram pra 
    //tras e precisam ser deletados.
    private List<GameObject> activeTiles;

    // Criando uma area segura de exclusão da funcao deletetile()
    private float safeZone = 100.0f;

    // Criando uma variavel para nunca instanciar a mesma prefab de mapa
    private int lastPrefabIndex = 0;

    //Spawn block é o bloco onde o jogador spawna
    public GameObject spawn_block;




	// Use this for initialization
	void Start () {

        //Instanciando as listas
        activeTiles = new List<GameObject>();

        // Sempre instanciando mais tiles com o for, daí pra tirar os tiles de tras fica na funcao update
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            //If para instanciar os 2 primeiros tiles comuns pra depois começar aleatoriedade.
            if ( i < 2 )
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
           

        }
            
        // Começa a contagem de 3 segundos para deletar o spawn block
        StartCoroutine("Wait");

    }
	
	// Update is called once per frame
	void Update () {

        // lembra de mudar a rotacao pra que quando o player caia o que conte seja o X
        if (playerTransform.position.x - safeZone > (spawnX - amnTilesOnScreen * tilelenght ))
            {

            SpawnTile();
            DeleteTile();

            }
		


	}

    // esse prefab index é um parametro pra receber uma das prefabs do array , vai servir pra aleatoriedade
    private void SpawnTile(int prefabIndex = -1)
    {
        // go é game object
        GameObject go;

        //IF para instanciar primeiro o indice de valor -1 primeiro
        if(prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        
        // sempre que instanciar uma nova ponte ela será filha da manager
        go.transform.SetParent(transform);
        //esta linha de codigo é pra colocar o prefab instanciado no lugar certo
        go.transform.position = gameObject.transform.position;
        go.transform.Translate( spawnX, 0, 0);
        spawnX += tilelenght;

        //Adicionando na lista sempre que spawnar um tile novo
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        // Se a distancia for menor que a de um tile retorne o valor 0 , que no array significa o primeiro tile 
        //para ser instanciado
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }
        // Declarando valor aleatorio para instanciar tiles, depois criando um loop para você nunca obter o mesmo
        //valor seguido ( nunca vai instanciar 2 tiles juntos seguidos pois eles vao se manter dentro do loop até
        //sair um valor diferente
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        //Quando ele sai com um numero diferente do loop ele retorna o valor aleatorio que obteve.
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    // Funcao para deletar o spawn block depois de uns 3 segundos
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        Destroy(spawn_block);
        
    }

}
