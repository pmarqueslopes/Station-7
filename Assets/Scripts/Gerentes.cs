using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerentes : MonoBehaviour
{

    private GameManager gm;
    public int indexGe;
    public GameObject[] botaoComprar;
    bool comprou = false;
    private void Update()
    {
        podeUparDuracaoM(indexGe);
    }

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }


    public void podeUparDuracaoM(int indexGe)
    {
        if (gm.dinheiro >= 500&& comprou ==false)
        {
            
            botaoComprar[0].SetActive(true);
            botaoComprar[1].SetActive(false);
            
        }
        else if (gm.dinheiro < 500)
        {
            botaoComprar[0].SetActive(false);
            botaoComprar[1].SetActive(true);
        }
        
    }

    public void uparGetente(int indexGe)
    {
        if  (gm.dinheiro >= 500)
        {    
            gm.gerentes[indexGe] = true;
            gm.dinheiro -= 500;
            comprou = true;
            FindObjectOfType<AudioManager>().Play("comprou");

        }
       
    }
    
}
