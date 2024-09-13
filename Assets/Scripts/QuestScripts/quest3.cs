using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest3 : MonoBehaviour
{
    public GameManager gm;
    public Text texto;
    public GameObject button;

    public void Update()
    {
        if (gm.UP_NVL_tamanhoServico[0] >= 2)
         {
             Destroy(this.gameObject);
             texto.color = Color.green;
             button.SetActive(true);
         }
    }
}
