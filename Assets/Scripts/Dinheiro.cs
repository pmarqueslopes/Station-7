using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinheiro : MonoBehaviour
{

    public int custo; //custo para construir
    public int ganharDinheiro; //dinheiro que ganha
    public float tempoDinheiro; //intervalo para ganhar dinheiro
    private CntrlPainel painelCompra;

    private GameManager gm; 
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>(); //acessar o dinheiro do outro script
        painelCompra = FindObjectOfType<CntrlPainel>();

        StartCoroutine("GanharDinheiro");
    }

    IEnumerator GanharDinheiro()
    {
        yield return new WaitForSeconds(tempoDinheiro);
        gm.dinheiro += ganharDinheiro;
        FindObjectOfType<AudioManager>().Play("Dinheiro");
        StartCoroutine("GanharDinheiro");
        //painelCompra.podeUparTamanho(gm.idServico, int x)
    }

}
