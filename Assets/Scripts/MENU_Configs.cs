using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU_Configs : MonoBehaviour {

    public GameObject pause_menu_UI;
    public GameObject score_menu_UI;
    public GameObject bonus_menu_UI;

    public void MudaCena(string nome_cena)
    {
        Time.timeScale = 1f;
        Application.LoadLevel(nome_cena);
    }

    public void troca_bonus()
    {
        pause_menu_UI.SetActive(false);
        bonus_menu_UI.SetActive(true);
    }
    public void troca_bonus_sair()
    {
        pause_menu_UI.SetActive(true);
        bonus_menu_UI.SetActive(false);
    }

}
