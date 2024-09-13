using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroLava : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    public GameObject iconeLava;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[2];
            gm.dinheiroServico[2] = 0;
            iconeLava.SetActive(false);
        }
    }
}
