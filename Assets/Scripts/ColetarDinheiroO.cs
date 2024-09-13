using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroO : MonoBehaviour
{
    private GameManager gm;
    public GameObject iconeOficina;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[0];
            gm.dinheiroServico[0] = 0;
            iconeOficina.SetActive(false);
        }            
    }
}
