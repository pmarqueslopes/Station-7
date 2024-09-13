using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroLazer : MonoBehaviour
{
    private GameManager gm;
    public GameObject iconeLazer;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[6];
            gm.dinheiroServico[6] = 0;
            iconeLazer.SetActive(false);
        }
    }
}
