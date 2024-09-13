using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInGameHUD : MonoBehaviour
{
    public GameObject TelaSupCoin;
    public GameObject TelaPause;
    public GameObject TelaSupVaga;

    public void AbrirSuporte(GameObject TelaSup)
    {
        TelaSup.SetActive(true);
    }

    public void FecharTela(GameObject TelaSup)
    {
        TelaSup.SetActive(false);
    }

    public void TrocarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void Pause()
    {
        TelaPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu!");
    }

    public void EscalaTempo(float t)
    {
        Time.timeScale = t;
    }
}
