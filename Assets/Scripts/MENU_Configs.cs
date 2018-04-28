using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU_Configs : MonoBehaviour {

    public void MudaCena(string nome_cena)
    {
        Application.LoadLevel(nome_cena);
    }
}
