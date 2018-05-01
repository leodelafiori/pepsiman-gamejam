using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU_Configs : MonoBehaviour {

    public void MudaCena(string nome_cena)
    {
        Time.timeScale = 1f;
        Application.LoadLevel(nome_cena);
    }

}
