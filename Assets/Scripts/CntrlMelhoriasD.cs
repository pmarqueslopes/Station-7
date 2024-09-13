using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CntrlMelhoriasD : MonoBehaviour
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
        podeUparDuracaoM(indexServico);
        podeUparDuracaoG(indexServico);
    }

    public void podeUparDuracaoM(int id)
    {
        if (gm.dinheiro >= gm.valorUpgradeDuracao[id] && gm.UP_NVL_duracaoServico[id] == 1)
        {
            segundoPonto.color = cor[1];
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
            
        }
        else if (gm.dinheiro < gm.valorUpgradeDuracao[id] && gm.UP_NVL_duracaoServico[id] == 1)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
        else if (gm.UP_NVL_duracaoServico[id] == 2)
        {
            segundoPonto.color = cor[2];
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
    }

    public void podeUparDuracaoG(int id)
    {
        if (gm.dinheiro >= gm.valorUpgradeDuracao[id] && gm.UP_NVL_duracaoServico[id] == 2)
        {
            terceiroPonto.color = cor[1];
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
        }
        else if (gm.dinheiro < gm.valorUpgradeDuracao[id] && gm.UP_NVL_duracaoServico[id] == 2)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
        else if (gm.UP_NVL_duracaoServico[id] == 3)
        {
            terceiroPonto.color = cor[2];
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
    }

    public void upouDuracaoM(int id)
    {
        if (gm.UP_NVL_duracaoServico[id] == 2)
        {
            segundoPonto.color = cor[2];
            
        }
    }

    public void upouDuracaoG(int id)
    {
        if (gm.UP_NVL_duracaoServico[id] == 3)
        {
            terceiroPonto.color = cor[2];
            
        }
    }
}
