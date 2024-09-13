using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroComida : MonoBehaviour
{
    private GameManager gm;
    public GameObject iconeComida;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[5];
            gm.dinheiroServico[5] = 0;
            iconeComida.SetActive(false);
        }
    }
}
