using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CntrlGerador : MonoBehaviour
{
    

    private GameManager gm;
    private Factory factory;
    


    public void Spawn()
    {
        factory.CreateEnemy();
        Invoke("Spawn", gm.tempoPopularidade);
    }

    public void Start()
    {
        gm = FindObjectOfType<GameManager>();
        factory = FindObjectOfType<Factory>();
        Invoke("Spawn", gm.tempoPopularidade);
    }

    
}
