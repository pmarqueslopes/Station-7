using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentocarroproblema : MonoBehaviour
{
    public Transform[] pontosentrada;
    public int index;
    public float speed;

    void FixedUpdate()
    {
        Vector3 dir = pontosentrada[index].position - transform.position;
        if (dir.magnitude <= 0.1f)
        {
            index = (index + 1) % pontosentrada.Length;
        }
        transform.position += dir.normalized * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.name == "Combustiveis"))
        {
            StartCoroutine(Saindo());
        }
    }
    IEnumerator Saindo()
    {

        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(this.gameObject);
        speed = 20;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
