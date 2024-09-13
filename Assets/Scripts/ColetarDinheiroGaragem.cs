using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroGaragem : MonoBehaviour
{
    
    private GameManager gm;
    public GameObject iconeGaragem;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[3];
            gm.dinheiroServico[3] = 0;
            iconeGaragem.SetActive(false);
        }
    }
}
