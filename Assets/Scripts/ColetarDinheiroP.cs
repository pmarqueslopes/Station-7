using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarDinheiroP : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    public GameObject iconePosto;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gm.dinheiro += gm.dinheiroServico[1];
            gm.dinheiroServico[1] = 0;
            iconePosto.SetActive(false);
        }
    }
}
