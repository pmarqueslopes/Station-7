using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData : MonoBehaviour
{

    public int dinheiro;
    public int chanceServico;
    public float tempoPopularidade;
    public int tipoCarro;

    public int[] UP_NVL_tamanhoServico;
    public int[] servicoTotal = new int[7];
    public int[] UP_NVL_lucroServico = new int[7];
    public int[] multiplicadorServico = new int[7];
    public int[] UP_NVL_duracaoServico = new int[7];
    public int[] tempoServico = new int[7];
    public bool[] gerentes = new bool[3];



    public PlayerData (GameManager gm)
    {
        dinheiro = gm.dinheiro;
        chanceServico = gm.chanceServico;
        tempoPopularidade = gm.tempoPopularidade;
        tipoCarro = gm.tipoCarro;
        
        UP_NVL_tamanhoServico[0] = gm.UP_NVL_tamanhoServico[0];
        UP_NVL_tamanhoServico[1] = gm.UP_NVL_tamanhoServico[1];
        UP_NVL_tamanhoServico[2] = gm.UP_NVL_tamanhoServico[2];
        UP_NVL_tamanhoServico[3] = gm.UP_NVL_tamanhoServico[3];
        UP_NVL_tamanhoServico[4] = gm.UP_NVL_tamanhoServico[4];
        UP_NVL_tamanhoServico[5] = gm.UP_NVL_tamanhoServico[5];
        UP_NVL_tamanhoServico[6] = gm.UP_NVL_tamanhoServico[6];

        servicoTotal[0] = gm.servicoTotal[0];
        servicoTotal[1] = gm.servicoTotal[1];
        servicoTotal[2] = gm.servicoTotal[2];
        servicoTotal[3] = gm.servicoTotal[3];
        servicoTotal[4] = gm.servicoTotal[4];
        servicoTotal[5] = gm.servicoTotal[5];
        servicoTotal[6] = gm.servicoTotal[6];

        UP_NVL_lucroServico[0] = gm.UP_NVL_lucroServico[0];
        UP_NVL_lucroServico[1] = gm.UP_NVL_lucroServico[1];
        UP_NVL_lucroServico[2] = gm.UP_NVL_lucroServico[2];
        UP_NVL_lucroServico[3] = gm.UP_NVL_lucroServico[3];
        UP_NVL_lucroServico[4] = gm.UP_NVL_lucroServico[4];
        UP_NVL_lucroServico[5] = gm.UP_NVL_lucroServico[5];
        UP_NVL_lucroServico[6] = gm.UP_NVL_lucroServico[6];

        multiplicadorServico[0] = gm.multiplicadorServico[0];
        multiplicadorServico[1] = gm.multiplicadorServico[1];
        multiplicadorServico[2] = gm.multiplicadorServico[2];
        multiplicadorServico[3] = gm.multiplicadorServico[3];
        multiplicadorServico[4] = gm.multiplicadorServico[4];
        multiplicadorServico[5] = gm.multiplicadorServico[5];
        multiplicadorServico[6] = gm.multiplicadorServico[6];

        UP_NVL_duracaoServico[0] = gm.UP_NVL_duracaoServico[0];
        UP_NVL_duracaoServico[1] = gm.UP_NVL_duracaoServico[1];
        UP_NVL_duracaoServico[2] = gm.UP_NVL_duracaoServico[2];
        UP_NVL_duracaoServico[3] = gm.UP_NVL_duracaoServico[3];
        UP_NVL_duracaoServico[4] = gm.UP_NVL_duracaoServico[4];
        UP_NVL_duracaoServico[5] = gm.UP_NVL_duracaoServico[5];
        UP_NVL_duracaoServico[6] = gm.UP_NVL_duracaoServico[6];

        tempoServico[0] = gm.tempoServico[0];
        tempoServico[1] = gm.tempoServico[1];
        tempoServico[2] = gm.tempoServico[2];
        tempoServico[3] = gm.tempoServico[3];
        tempoServico[4] = gm.tempoServico[4];
        tempoServico[5] = gm.tempoServico[5];
        tempoServico[6] = gm.tempoServico[6];

        gerentes[0] = gm.gerentes[0];
        gerentes[1] = gm.gerentes[1];
        gerentes[2] = gm.gerentes[2];

    }
    

}
