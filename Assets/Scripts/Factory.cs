using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject[] prefabs;
    private GameManager gm;
    

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public GameObject CreateEnemy()
    {
        int i = Random.Range(0,gm.tipoCarro);
        

        GameObject carro = Instantiate<GameObject>(prefabs[i], prefabs[i].transform.position, prefabs[i].transform.rotation);
        
        return carro;
        
    }
}