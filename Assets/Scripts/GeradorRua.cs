using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorRua : MonoBehaviour
{
    public GameObject[] carros;
    public GameObject geradorRua;
    
    public void gerar()
    {
      
        int sorteio = Random.Range(0,carros.Length);
        Instantiate(carros[sorteio], geradorRua.transform.position, geradorRua.transform.rotation);

        
    }
    void Start()
    {
        
        InvokeRepeating("gerar", 1, 12);
    }
}
