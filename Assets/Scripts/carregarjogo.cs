using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carregarjogo : MonoBehaviour
{
    public void CarregaCena()
    {
        SceneManager.LoadScene("Game");
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu!!!!!");
    }
}