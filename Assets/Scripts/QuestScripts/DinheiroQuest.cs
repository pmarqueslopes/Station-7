using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinheiroQuest : MonoBehaviour
{
    private GameManager gm;
    public int ganhar = 0;

    void Start()
    {
        gm = FindObjectOfType<GameManager>(); //acessar o dinheiro do outro script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Coleta()
    {
        gm.dinheiro += ganhar;
    }
}
