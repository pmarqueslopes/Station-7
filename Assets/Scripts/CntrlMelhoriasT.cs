using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CntrlMelhoriasT: MonoBehaviour
{
    public Image segundoPonto, terceiroPonto;
    public Color[] cor;
    private GameManager gm;
    public GameObject[] botaoComprar;
    public int indexServico;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        podeUparTamanhoM(indexServico);
        podeUparTamanhoG(indexServico);
    }

    public void podeUparTamanhoM(int id)
    {
        if(gm.dinheiro >= gm.valorUpgradeTamanho[id] && gm.UP_NVL_tamanhoServico[id] == 1)
        {
            segundoPonto.color = cor[1];
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
        } else if (gm.dinheiro < gm.valorUpgradeTamanho[id] && gm.UP_NVL_tamanhoServico[id] == 1)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        } else if (gm.UP_NVL_tamanhoServico[id] == 2)
        {
            segundoPonto.color = cor[2];
        }
    }

    public void podeUparTamanhoG(int id)
    {
        if (gm.dinheiro >= gm.valorUpgradeTamanho[id] && gm.UP_NVL_tamanhoServico[id] == 2)
        {
            terceiroPonto.color = cor[1];
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
        }
        else if (gm.dinheiro < gm.valorUpgradeTamanho[id] && gm.UP_NVL_tamanhoServico[id] == 2)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
        else if (gm.UP_NVL_tamanhoServico[id] == 3)
        {
            terceiroPonto.color = cor[2];
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
    }

    public void upouTamanhoM(int id)
    {
        if (gm.UP_NVL_tamanhoServico[id] == 2)
        {
            segundoPonto.color = cor[2];
            
        }
    }

    public void upouTamanhoG(int id)
    {
        if (gm.UP_NVL_tamanhoServico[id] == 3)
        {
            terceiroPonto.color = cor[2];
            
        }
    }
}
