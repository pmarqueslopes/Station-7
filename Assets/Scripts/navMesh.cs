using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class navMesh : MonoBehaviour
{
    public int IdServicoFixo;
    
    public NavMeshAgent agent;
    private GameManager gm;

   
    public GameObject[] Imagens;

    public int indexVaga;
    public int vagaServico;
    public bool estacionado;
    public bool esperando;

    public bool conferiu = false;
    

    public ColetarDinheiroO coletarScriptO;
    public ColetarDinheiroP coletarScriptP;
    public ColetarDinheiroLava coletarScriptLava;
    public ColetarDinheiroGaragem coletarScriptGaragem;
    public ColetarDinheiroLoja coletarScriptLoja;
    public ColetarDinheiroComida coletarScriptComida;
    public ColetarDinheiroLazer coletarScriptLazer;


    private void Awake()
    {
       
    }

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        coletarScriptO = FindObjectOfType<ColetarDinheiroO>();
        coletarScriptP = FindObjectOfType<ColetarDinheiroP>();
        coletarScriptLava = FindObjectOfType<ColetarDinheiroLava>();
        coletarScriptLoja = FindObjectOfType<ColetarDinheiroLoja>();
        coletarScriptComida = FindObjectOfType<ColetarDinheiroComida>();
        coletarScriptGaragem = FindObjectOfType<ColetarDinheiroGaragem>();
        coletarScriptLazer = FindObjectOfType<ColetarDinheiroLazer>();

        AleatorizarServico();
        agent.SetDestination(gm.posicaoConferir.transform.position);
        estacionado = false;
        Imagens[IdServicoFixo].SetActive(true);
    }

    void AleatorizarServico()
    {
        IdServicoFixo = Random.Range(0, gm.servicosDisponiveis);
    }
    
    public void Conferir(Collider other)
    {
         if (other.gameObject.CompareTag("conferir")&& conferiu ==false)
         {
            ProcurarServico();
           
         }
    }


    public void ProcurarServico()
    {
        Debug.Log("Conferiu");
        conferiu = true;
        switch (IdServicoFixo)
        {
            case 0: VagaOficina();
                break;
            case 1: VagaPosto();
                break;
             case 2: VagaLava();
                break;
            case 3: CheckServico(); break;
            default: CheckServicoAux(); break;
                
                
        }
      
    }

    

    public void VagaOficina()
    {
        for (int i = 0; i < gm.vagasOficinaTotal; i++)
        {
            if (gm.boolOficina[i] == true)
            {
                agent.SetDestination(gm.prevagasOficina[i].transform.position);
                
                gm.boolOficina[i] = false;
                gm.vagasDispOficina--;
                indexVaga = i;
                esperando = true;
                break;
            }
            else if (gm.vagasDispOficina <= 0)
            {
                sairRaiva();
            }
           
        }
    }
    public void VagaPosto()
    {
        for (int i = 0; i < gm.vagasPostoTotal; i++)
        {
            if (gm.boolPosto[i] == true)
            {
                agent.SetDestination(gm.prevagasPosto[i].transform.position);
                
                gm.boolPosto[i] = false;
                gm.vagasDispPosto--;
                indexVaga = i;
                esperando = true;
                break;
            }
            else if (gm.vagasDispPosto <= 0)
            {
                sairRaiva();
            }

        }
    }
    public void VagaLava()
    {
        for (int i = 0; i < gm.vagasLavaTotal; i++)
        {
            if (gm.boolLava[i] == true)
            {
                agent.SetDestination(gm.prevagasLava[i].transform.position);
                
                gm.boolLava[i] = false;
                gm.vagasDispLava--;
                indexVaga = i;
                esperando = true;
                break;
            }
            else if (gm.vagasDispLava <= 0)
            {
                sairRaiva();
            } 

        }
    }

    public void CheckServico()
    {
        if (gm.servicoOcupado[IdServicoFixo] < gm.servicoTotal[IdServicoFixo])
        { agent.SetDestination(gm.Checkpoint[IdServicoFixo].transform.position);
            gm.servicoOcupado[IdServicoFixo]++;
            estacionado = false;
            
            switch (IdServicoFixo)
            {
                case 0: gm.boolOficina[indexVaga] = true;gm.vagasDispOficina++; break;
                case 1: gm.boolPosto[indexVaga] = true;gm.vagasDispPosto++; break;
                case 2: gm.boolLava[indexVaga] = true;gm.vagasDispLava++; break;
            }

           

            Imagens[IdServicoFixo].SetActive(false);
        } 
        else if(IdServicoFixo ==3 && gm.servicoOcupado[IdServicoFixo] >= gm.servicoTotal[IdServicoFixo])
        {
            sairRaiva();
        }
    }

    public void CheckServicoAux()
    {
        if (gm.servicoOcupado[IdServicoFixo] < gm.servicoTotal[IdServicoFixo])
        {
            agent.SetDestination(gm.Checkpoint[IdServicoFixo].transform.position);
            gm.servicoOcupado[IdServicoFixo]++; 
        }
        else
        {
            preSaida();
        }
    }


    private void OnMouseOver()
    {
        if (estacionado == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckServico();
            }
        }
    }
   public void ServicoOficina()
    {
        for (int i=0;i<gm.servicoTotal[0];i++)
        {
            if (gm.oficinaLivre[i] == true)
            {
                agent.SetDestination(gm.oficina[i].transform.position);
                gm.oficinaLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    }
    public void ServicoPosto()
    {
        for (int i = 0; i < gm.servicoTotal[1]; i++)
        {
            if (gm.postoLivre[i] == true)
            {
                agent.SetDestination(gm.posto[i].transform.position);
                gm.postoLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    } 
    public void ServicoLava()
    {
        for (int i = 0; i < gm.servicoTotal[2]; i++)
        {
            if (gm.lavaLivre[i] == true)
            {
                agent.SetDestination(gm.lava[i].transform.position);
                gm.lavaLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    }
public void ServicoGaragem()
    {
        for (int i = 0; i < gm.servicoTotal[3]; i++)
        {
            if (gm.garagemLivre[i] == true)
            {
                Debug.Log("iniciou garagem");
                agent.SetDestination(gm.garagem[i].transform.position);
                gm.garagemLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    }
    public void ServicoLoja()
    {
        for (int i = 0; i < gm.servicoTotal[4]; i++)
        {
            if (gm.lojaLivre[i] == true)
            {
                agent.SetDestination(gm.loja[i].transform.position);
                gm.lojaLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    }

    
    public void ServicoComida()
    {
        for (int i = 0; i < gm.servicoTotal[5]; i++)
        {
            if (gm.comidaLivre[i] == true)
            {
                agent.SetDestination(gm.comida[i].transform.position);
                gm.comidaLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    }

    public void ServicoLazer()
    {
        for (int i = 0; i < gm.servicoTotal[6]; i++)
        {
            if (gm.lazerLivre[i] == true)
            {
                agent.SetDestination(gm.lazer[i].transform.position);
                gm.lazerLivre[i] = false;
                vagaServico = i;
                break;
            }
        }
    }


    IEnumerator FinalizarServico()
    {
        switch (IdServicoFixo)
        {
            case 0:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.oficinaLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                agent.SetDestination(gm.saidaOficina.transform.position);
                coletarScriptO.iconeOficina.SetActive(true);
                break;

            case 1:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.postoLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                agent.SetDestination(gm.saidaPosto.transform.position);
                coletarScriptP.iconePosto.SetActive(true);

                break;
            case 2:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.lavaLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                agent.SetDestination(gm.saidaLava.transform.position);
                coletarScriptLava.iconeLava.SetActive(true);

                break;
            case 3:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.garagemLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                agent.SetDestination(gm.saidaGaragem.transform.position);
                coletarScriptGaragem.iconeGaragem.SetActive(true);
                break;
            case 4:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.lojaLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                preSaida();
                coletarScriptLoja.iconeLoja.SetActive(true);
                break;
            case 5:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.comidaLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                preSaida();
                coletarScriptComida.iconeComida.SetActive(true);
                break;
            case 6:
                yield return new WaitForSeconds(gm.tempoServico[IdServicoFixo]);
                gm.lazerLivre[vagaServico] = true;
                gm.servicoOcupado[IdServicoFixo]--;
                gm.dinheiroServico[IdServicoFixo] += 20 * gm.multiplicadorServico[IdServicoFixo];
                FindObjectOfType<AudioManager>().Play("dinheiro");
                preSaida();
                coletarScriptLazer.iconeLazer.SetActive(true);
                break;
        }
        
    }
    


    void SorteioNovoServico()
    {
        int rnd = Random.Range(0, 101);
        if (rnd <= gm.chanceServico)
        {
            int r = Random.Range(4, 7); //colocar variavel q muda a medida que compra os servicos
            IdServicoFixo = r;
            CheckServicoAux();
        }
        else{
            preSaida();
        }
    }

    void preSaida()
    {
        agent.SetDestination(gm.preSaida.transform.position);
    }

  public  void sairRaiva()
  {
        agent.SetDestination(gm.preSaida.transform.position);
        FindObjectOfType<AudioManager>().Play("grr");
        Imagens[IdServicoFixo].SetActive(false);

  }

  
    public void Sair(Collider other)
    {
        if (other.gameObject.CompareTag("preSaida"))
        {
            agent.SetDestination(gm.saida.transform.position);
        }
        
    }

    public void preVagasOficina(Collider other)
    {
        if (other.gameObject.CompareTag("preOficina"))
        {
            agent.SetDestination(gm.vagasOficina[indexVaga].transform.position);
        }
    }
    public void preVagasPosto(Collider other)
    {
        if (other.gameObject.CompareTag("prePosto"))
        {
            agent.SetDestination(gm.vagasPosto[indexVaga].transform.position);
        }
    }
    public void preVagasLava(Collider other)
    {
        if (other.gameObject.CompareTag("preLava"))
        {
            agent.SetDestination(gm.vagasLava[indexVaga].transform.position);
        }
    }
    public void saidaServico(Collider other)
    {
        if (other.gameObject.CompareTag("saidaServico"))
        {
            SorteioNovoServico();
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        Conferir(other);
        Destruir(other);
        preVagasOficina(other);
        preVagasPosto(other);
        preVagasLava(other);
        CheckpointServico(other);
        aCaminhoServico(other);
        Sair(other);
        //SumirMesh(other);
        saidaServico(other);
        Estacionado(other);

    }


    IEnumerator CheckarGerente()
    {
        if (estacionado==true)
        {     
            if(gm.gerentes[IdServicoFixo] == true)
            {
                    Debug.Log(gameObject.name + "checando");


                    if (gm.servicoOcupado[IdServicoFixo] < gm.servicoTotal[IdServicoFixo])
                    {
                        CheckServico();
                    }

            }

                yield return new WaitForSeconds(5);
            

            StartCoroutine(CheckarGerente());
        }
        
    }


    void Estacionado(Collider other)
    {
        if (other.gameObject.CompareTag("Vaga"))
        {
            estacionado = true;

                StartCoroutine(CheckarGerente());
        }
    }

   
    public void Destruir(Collider other)
    {
    if (other.gameObject.CompareTag("destruir"))
            {
                Destroy(this.gameObject);
            }
    }



    public void aCaminhoServico(Collider other)
    {
        if (other.gameObject.CompareTag("conserto0") && IdServicoFixo == 0)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("oficina");
        }
        if (other.gameObject.CompareTag("conserto1") && IdServicoFixo == 1)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("posto");
        }
        if (other.gameObject.CompareTag("conserto2") && IdServicoFixo == 2)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("lava");
        }
        if (other.gameObject.CompareTag("conserto3") && IdServicoFixo == 3)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("garagem");

        }
        if (other.gameObject.CompareTag("conserto4") && IdServicoFixo == 4)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("loja");
        }
        if(other.gameObject.CompareTag("conserto5") && IdServicoFixo == 5)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("comida");
        }
        if (other.gameObject.CompareTag("conserto6") && IdServicoFixo == 6)
        {
            StartCoroutine(FinalizarServico());
            FindObjectOfType<AudioManager>().Play("lazer");
        }



    }

        public void CheckpointServico(Collider other)
    {
        if (other.gameObject.CompareTag("checkPointOficina")&& IdServicoFixo ==0)
        {
            ServicoOficina();
            Debug.Log("colidiu oficina");

        }
        else if (other.gameObject.CompareTag("checkPointPosto") && IdServicoFixo == 1)
        {
            ServicoPosto();
            Debug.Log("colidiu posto");
        }
        else if (other.gameObject.CompareTag("checkPointLava") && IdServicoFixo == 2)
        {
            ServicoLava();

            Debug.Log("colidiu lava");
        } 
        else if (other.gameObject.CompareTag("checkPointGaragem") && IdServicoFixo == 3)
        {
            ServicoGaragem();
            Debug.Log("colidiu garagem");

        }
        else if (other.gameObject.CompareTag("checkPointLoja") && IdServicoFixo == 4)
        {
            ServicoLoja();
            Debug.Log("colidiu loja");
        }
      
        else if (other.gameObject.CompareTag("checkPointComida") && IdServicoFixo == 5)
        {
            ServicoComida();
            Debug.Log("colidiu comida");

        }
        else if (other.gameObject.CompareTag("checkPointLazer") && IdServicoFixo == 6)
        {
            ServicoLazer();
            Debug.Log("colidiu lazer");

        }


    }
   
    void Update()
    {
        
    }
}
