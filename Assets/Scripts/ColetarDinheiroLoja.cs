using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroLoja : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    public GameObject iconeLoja;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[4];
            gm.dinheiroServico[4] = 0;
            iconeLoja.SetActive(false);
        }
    }
}
