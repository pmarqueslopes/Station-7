using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CntrlMelhoriasL : MonoBehaviour
{
    public Image segundoPonto, terceiroPonto;
    public Color[] cor;
    private GameManager gm;
    public GameObject[] botaoComprar;
    public int indexServico;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        podeUparLucroM(indexServico);
        podeUparLucroG(indexServico);
    }

    public void podeUparLucroM(int id)
    {
        if (gm.dinheiro >= gm.valorUpgradeLucro[id] && gm.UP_NVL_lucroServico[id] == 1)
        {
            segundoPonto.color = cor[1];
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
        }
        else if (gm.dinheiro < gm.valorUpgradeLucro[id] && gm.UP_NVL_lucroServico[id] == 1)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
        else if (gm.UP_NVL_lucroServico[id] == 2)
        {
            segundoPonto.color = cor[2];
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
    }

    public void podeUparLucroG(int id)
    {
        if (gm.dinheiro >= gm.valorUpgradeLucro[id] && gm.UP_NVL_lucroServico[id] == 2)
        {
            terceiroPonto.color = cor[1];
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
        }
        else if (gm.dinheiro < gm.valorUpgradeLucro[id] && gm.UP_NVL_lucroServico[id] == 2)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
        else if (gm.UP_NVL_lucroServico[id] == 3)
        {
            terceiroPonto.color = cor[2];
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
    }

    public void upouLucroM(int id)
    {
        if (gm.UP_NVL_lucroServico[id] == 2)
        {
            segundoPonto.color = cor[2];

        }
    }

    public void upouLucroG(int id)
    {
        if (gm.UP_NVL_lucroServico[id] == 3)
        {
            terceiroPonto.color = cor[2];

        }
    }
}
