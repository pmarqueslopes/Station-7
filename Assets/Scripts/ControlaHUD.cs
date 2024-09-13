using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaHUD : MonoBehaviour
{
    public GameObject TelaCreditos;
    public GameObject TelaMenu;
    public GameObject TelaInstrucoes;



    public void TrocarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

    public void AbrirTela(GameObject tela)
    {
        tela.SetActive(true);
    }

    public void FecharTela(GameObject tela)
    {
        tela.SetActive(false);
    }
}
