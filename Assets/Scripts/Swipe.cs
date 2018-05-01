using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    //Criacao de classe para identificar o input do usuario


    //Criando variaveis bool pra identificacao
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    //Verificar se o dedo está pressionando a tela
    public bool isDraging = false;
    public Vector2 startTouch, swipeDelta;

    private void Update()
    {
        // Resetando todas as bools todos os frames
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Inputs do PC-mouse

        // Button down é dedo pressionado e no else if button up é dedo fora da tela
        // Isso significa que movimentos de swipe acontecem entre este if e else.
        if (Input.GetMouseButtonDown(0))
        {
            // tranforma o tap em true e começa a "traquear"
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Se tirar o dedo ele reseta
            Reset();
            isDraging = false;
            
        }
        
        #endregion

        #region Mobile inputs
        //Nesta regiao é coletado dados touch se for maior que 0 a distancia
        //do swipe
        if (Input.touches.Length > 0)
        {
            //Comeca a receber o swipe com comandos touchphase do unity
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }

            //Se o movimento for cancelado ou terminado ele da um reset
            else if ( Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }



        #endregion

        // Calculando a distancia enquanto o touch estiver pressionado
        swipeDelta = Vector2.zero;
        //Verifica se o start touch nao for zero, porque basicamente significa que
        //o comando swipe começou de algum lugar
        if (isDraging)
        {
            // Estes ifs servem para subtrair a posição que comecou da posição que o dedo parou
            //no swipe, para ambos mouse e dedo no celular
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // Verificacao se a "deadzone" no centro foi ultrapassada para gerar um swipe
        if(swipeDelta.magnitude > 100)
        {
            //Verificando a direção do swipe que ocorreu
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            //Se entrar neste if significa que entramos no X axis
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Verificando se é direita ou esquerda pelo X
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            //Se entrar neste else significa que foi para cima ou para baixo
            else
            {
                //Verificando se é pra cima ou pra baixo pelo Y
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }

            }

            Reset();
        }


    }

    // Reset para ser realizado apos a interacao
    private void Reset()
    {
        isDraging = false;
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
    }


}
