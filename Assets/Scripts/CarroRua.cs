using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarroRua : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject saida;

    void Start()
    {
        Sair();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("destruir"))
        {

            Destroy(this.gameObject);
        }
    }
   void Sair()
    {
        agent.SetDestination(saida.transform.position);
    }
    
}
