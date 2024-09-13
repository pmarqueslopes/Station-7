using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CntrlPainel : MonoBehaviour
{
    public Image[] bts_compra;
    public Image[] pontosDeProgressao;
    public Color[] cor;
    private GameManager gm;
    public int indexServico;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void podeUparTamanho(int id)
    {
        if(gm.UP_NVL_tamanhoServico[id] == 1)
        {
            if (gm.dinheiro >= gm.valorUpgradeTamanho[id] && gm.UP_NVL_tamanhoServico[id] == 1)
            {
                bts_compra[0].color = cor[2];
                Debug.Log("pode upar");
            }
            else
            {
                bts_compra[0].color = cor[1];
            }
        }
        else if(gm.UP_NVL_tamanhoServico[id] == 2)
        {
            if (gm.dinheiro >= gm.valorUpgradeTamanho[id] && gm.UP_NVL_tamanhoServico[id] == 2)
            {
                bts_compra[0].color = cor[2];
                Debug.Log("pode upar");
            }
            else
            {
                bts_compra[0].color = cor[1];
            }
        }  
    }

    public void upouTamanho(int id, int tipo)
    {
        switch (tipo)
        {
            case 0:
                if (gm.UP_NVL_tamanhoServico[id] == 2)
                {
                    pontosDeProgressao[0].color = cor[2];
                    bts_compra[0].color = cor[1];
                    Debug.Log("upou para o 2");
                }
                break;

            case 1:
                if (gm.UP_NVL_tamanhoServico[id] == 3)
                {
                    pontosDeProgressao[1].color = cor[2];
                    bts_compra[0].color = cor[1];
                    Debug.Log("upou para o 3");
                }
                break;
        } 
    }
}
