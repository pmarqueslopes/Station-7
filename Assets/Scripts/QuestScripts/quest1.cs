using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest1 : MonoBehaviour
{
    public GameManager gm;
    public Text texto;
    public GameObject button;


    void Start()
    {
        gm = FindObjectOfType<GameManager>(); //acessar o dinheiro do outro script
    }
    public void Update()
    {
        if (gm.dinheiro >= 40)
        {
            Destroy(this.gameObject);
            texto.color = Color.green;
            button.SetActive(true);
        }
    }

    public void Coleta()
    {
        gm.dinheiro += 50;
    }
}
