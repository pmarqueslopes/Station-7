using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
public class GameManager : MonoBehaviour
{
    
     

public bool[] gerentes;

    public TextMeshProUGUI[] valoresTamanho, valoresLucro, valoresDuracao;
    public int[] dinheiroServico = new int[4];
    public int dinheiro; //dinheiro do player
    public Text dinheiroText; //mostrar dinheiro na HUD
    public GameObject[] vagasOficina; //lista de vagas da oficina
    public GameObject[] prevagasOficina;
    public GameObject[] vagasPosto;//lista de vagas do posto
    public GameObject[] prevagasPosto;
    public GameObject[] vagasLava;//lista de vagas do lavajato
    public GameObject[] prevagasLava;
    public int vagasDispOficina; //numero de vagas disponiveis da oficina
    public int vagasDispPosto;//numero de vagas disponiveis do posto
    public int vagasDispLava;//numero de vagas disponiveis do lavajato

    public GameObject preSaida;
    public GameObject saida; // coordenação da saida
    public GameObject posicaoConferir;// coordenação da entrada
    public GameObject[] Checkpoint; // coordenação dos checkpoints

    public bool[] boolPosto; //boleana para ver se as vagas do posto estao disponiveis
    public bool[] boolOficina;//boleana para ver se as vagas da oficina estao disponiveis
    public bool[] boolLava;//boleana para ver se as vagas do lavajato estao disponiveis
   

    public GameObject[] oficina; //lista do servico da oficina
    public GameObject saidaOficina;
    public GameObject[] posto;//lista do servico do posto
    public GameObject saidaPosto;
    public GameObject[] lava;//lista do servico do lavajato
    public GameObject saidaLava;
    public GameObject[] loja;//lista do servico da loja
    public GameObject[] garagem;//lista do servico da garagem
    public GameObject saidaGaragem;
    public GameObject[] comida;//lista do servico da comida
    public GameObject[] lazer;//lista do servico do lazer


    public bool[] postoLivre = new bool[4]; //boleana para ver se os servicos do posto estao disponiveis
    public bool[] oficinaLivre = new bool[3];///boleana para ver se os servicos da oficina estao disponiveis
    public bool[] lavaLivre = new bool[3];//boleana para ver se os servicos do lavajato estao disponiveis
    public bool[] garagemLivre = new bool[3];//boleana para ver se os servicos da garagem estao disponiveis
    public bool[] lojaLivre = new bool[3];//boleana para ver se os servicos da loja estao disponiveis
    public bool[] comidaLivre = new bool[3];//boleana para ver se os servicos da comida estao disponiveis
    public bool[] lazerLivre = new bool[3];//boleana para ver se os servicos do lazer estao disponiveis
   

    public Text vagastext;
   
    private ControlaInGameHUD hud;
    private CntrlMelhoriasT melhoriaT;
    private CntrlMelhoriasL melhoriaL;
    private CntrlMelhoriasD melhoriaD;
    private CntrlPainel painelCompra;


    public GameObject[] servico1, servico2, servico3, servico4,servico5,servico6,servico7; //lista dos modelos para upgrade

    public int chanceServico = 10; //chance de fazer outro servico

    public int [] servicoTotal; //total de espacos para o servico
    public int [] servicoOcupado; //total de servicos ocupados no momento
    public int [] multiplicadorServico; //multiplicador do valor de cada servico
    public int [] tempoServico; //tempo de duracao de cada servico

    

    public int[] UP_NVL_tamanhoServico;
    public int[] UP_NVL_lucroServico;
    public int[] UP_NVL_duracaoServico;

    
    public int vagasOficinaTotal; //vagas total da oficina
    public int vagasPostoTotal; //vagas total do posto
    public int vagasLavaTotal; //vagas total do lavajato
    private int t = 4;
    public int servicosDisponiveis = 3; //numero de servicos essenciais

    public int[] valorUpgradeTamanho; // 4 valores no vetor
    public int[] valorUpgradeLucro; // 4 valores no vetor
    public int[] valorUpgradeDuracao; // 4 valores no vetor

    public float tempoPopularidade;
    public int tipoCarro = 3;

    public ParticleSystem[] confetes;


    private void Awake()
    {
        painelCompra = FindObjectOfType<CntrlPainel>();
        melhoriaT = FindObjectOfType<CntrlMelhoriasT>();
        melhoriaL = FindObjectOfType<CntrlMelhoriasL>();
        melhoriaD = FindObjectOfType<CntrlMelhoriasD>();
        hud = FindObjectOfType<ControlaInGameHUD>();
        //servicosDisponiveis = 4;
        vagasOficinaTotal = 3;
        vagasPostoTotal = 3;
        vagasLavaTotal = 3;
        vagasDispOficina = 3;
        vagasDispPosto = 3;
        vagasDispLava = 3;
        //AjustarListas();
        AtualizarTextValores();
        tempoPopularidade = 20; //tempo para gerar novos carros
    }

    void Start()
    {
        Time.timeScale = 2;
    }

    void Update()
    {
        dinheiroText.text = dinheiro.ToString();
        //vagastext.text = vagas.ToString();
    }

    public void Despausar()
    {
        Time.timeScale = 1.0f;
    }      

    public void MelhorarTamanho(int idServico)
    {
        if (dinheiro >= valorUpgradeTamanho[idServico] && UP_NVL_tamanhoServico[idServico] == 1)
        {
            servicoTotal[idServico]++;
            
            UP_NVL_tamanhoServico[idServico] = 2;
            dinheiro -= valorUpgradeTamanho[idServico];
            tempoPopularidade -= 0.3f; 
             tipoCarro++;
            chanceServico += 2;
            FindObjectOfType<AudioManager>().Play("comprou");
            confetes[idServico].Play();
            TrocaDeTamanho(idServico, 1);
           // melhoriaT.upouTamanhoM(idServico);
            AtualizarTextValores();
        }
        else if (dinheiro >= valorUpgradeTamanho[idServico] && UP_NVL_tamanhoServico[idServico] == 2)
        {
            servicoTotal[idServico]++;
            
            UP_NVL_tamanhoServico[idServico] = 3;
            dinheiro -= valorUpgradeTamanho[idServico];
            tempoPopularidade -= 0.3f;
            chanceServico += 2;
            FindObjectOfType<AudioManager>().Play("comprou");
            confetes[idServico].Play();
            TrocaDeTamanho(idServico, 2);
            

           // melhoriaT.upouTamanhoG(idServico);
            AtualizarTextValores();
        }
    }

    public void MelhorarLucro(int idServico)
    {
        if (dinheiro >= valorUpgradeLucro[idServico] && UP_NVL_lucroServico[idServico] == 1) {
            dinheiro -= valorUpgradeLucro[idServico];
            multiplicadorServico[idServico] += 1;
            
            UP_NVL_lucroServico[idServico]++;
            tipoCarro++;
            tempoPopularidade -= 0.3f;
            chanceServico += 2; 
            FindObjectOfType<AudioManager>().Play("comprou");
            confetes[idServico].Play();
            // melhoriaL.upouLucroM(idServico);

            AtualizarTextValores();
        }

        else if(dinheiro >= valorUpgradeLucro[idServico] && UP_NVL_lucroServico[idServico] == 2){
            dinheiro -= valorUpgradeLucro[idServico];
            multiplicadorServico[idServico] += 2;
           
            UP_NVL_lucroServico[idServico]++;
            tempoPopularidade -= 0.3f;
            chanceServico += 2; 
            FindObjectOfType<AudioManager>().Play("comprou");
            confetes[idServico].Play();
            // melhoriaL.upouLucroG(idServico);

            AtualizarTextValores();
        }
    }

    public void MelhorarDuracao(int idServico)
    {
        if (dinheiro >= valorUpgradeDuracao[idServico] && UP_NVL_duracaoServico[idServico] == 1){
            dinheiro -= valorUpgradeDuracao[idServico];
            tempoServico[idServico] -= 2;
            
            UP_NVL_duracaoServico[idServico]++;
            
            tipoCarro++;
            tempoPopularidade -= 0.3f;
            chanceServico += 3;
            FindObjectOfType<AudioManager>().Play("comprou");
            confetes[idServico].Play();
            AtualizarTextValores();
           // melhoriaD.upouDuracaoM(idServico);
        }
        else if(dinheiro >= valorUpgradeDuracao[idServico] && UP_NVL_duracaoServico[idServico] == 2){
            dinheiro -= valorUpgradeDuracao[idServico];
            tempoServico[idServico] -= 4;
            
            UP_NVL_duracaoServico[idServico]++;
          
            tempoPopularidade -= 0.3f;
            chanceServico += 2;
            FindObjectOfType<AudioManager>().Play("comprou");
            confetes[idServico].Play();
            AtualizarTextValores();
           // melhoriaD.upouDuracaoG(idServico);
        }
    }

    public void TrocaDeTamanho(int x, int y) // feito para buscar a lista de serviços de acordo com o idServico
    {
        switch (x)
        {
            case 0:
                if (y == 1)
                {
                    servico1[0].SetActive(false);
                    servico1[1].SetActive(true);
                    melhoriaT.upouTamanhoM(x);
                }
                else if (y == 2)
                {
                    servico1[1].SetActive(false);
                    servico1[2].SetActive(true);
                    melhoriaT.upouTamanhoG(x);
                }
                break;

            case 1:
                if (y == 1)
                {
                    servico2[0].SetActive(false);
                    servico2[1].SetActive(true);
                    melhoriaT.upouTamanhoM(x);
                }
                else if (y == 2)
                {
                    servico2[1].SetActive(false);
                    servico2[2].SetActive(true);
                    melhoriaT.upouTamanhoG(x);
                }
                break;

            case 2:
                if (y == 1)
                {
                    servico3[0].SetActive(false);
                    servico3[1].SetActive(true);
                    melhoriaT.upouTamanhoM(x);
                }
                else if (y == 2)
                {
                    servico3[1].SetActive(false);
                    servico3[2].SetActive(true);
                    melhoriaT.upouTamanhoG(x);
                }
                break;

            case 3:
                if (y == 1)
                {
                    servico4[0].SetActive(false);
                    servico4[1].SetActive(true);
                    melhoriaT.upouTamanhoM(x);
                }
                else if (y == 2)
                {
                    servico4[1].SetActive(false);
                    servico4[2].SetActive(true);
                    melhoriaT.upouTamanhoG(x);
                }
                break;
            case 4:
                if (y == 1)
        {
            servico5[0].SetActive(false);
            servico5[1].SetActive(true);
            melhoriaT.upouTamanhoM(x);
        }
        else if (y == 2)
        {
            servico5[1].SetActive(false);
            servico5[2].SetActive(true);
            melhoriaT.upouTamanhoG(x);
        }
        break;

            case 5:
                if (y == 1)
                {
                    servico6[0].SetActive(false);
                    servico6[1].SetActive(true);
                    melhoriaT.upouTamanhoM(x);
                }
                else if (y == 2)
                {
                    servico6[1].SetActive(false);
                    servico6[2].SetActive(true);
                    melhoriaT.upouTamanhoG(x);
                }
                break;
            case 6:
                if (y == 1)
                {
                    servico7[0].SetActive(false);
                    servico7[1].SetActive(true);
                    melhoriaT.upouTamanhoM(x);
                }
                else if (y == 2)
                {
                    servico7[1].SetActive(false);
                    servico7[2].SetActive(true);
                    melhoriaT.upouTamanhoG(x);
                }
                break;
        }
    }
  
      public void AtualizarTextValores()
    {
        for (int i = 0; i < t; i++)
        {
            valoresTamanho[i].text = valorUpgradeTamanho[i].ToString();
            valoresLucro[i].text = valorUpgradeLucro[i].ToString();
            valoresDuracao[i].text = valorUpgradeDuracao[i].ToString();
        }
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();


        dinheiro = data.dinheiro;

        chanceServico = data.chanceServico;

        tempoPopularidade = data.tempoPopularidade;

        tipoCarro = data.tipoCarro;



        UP_NVL_tamanhoServico[0] = data.UP_NVL_tamanhoServico[0];

        UP_NVL_tamanhoServico[1] = data.UP_NVL_tamanhoServico[1];

        UP_NVL_tamanhoServico[2] = data.UP_NVL_tamanhoServico[2];

        UP_NVL_tamanhoServico[3] = data.UP_NVL_tamanhoServico[3];

        UP_NVL_tamanhoServico[4] = data.UP_NVL_tamanhoServico[4];

        UP_NVL_tamanhoServico[5] = data.UP_NVL_tamanhoServico[5];

        UP_NVL_tamanhoServico[6] = data.UP_NVL_tamanhoServico[6];



        servicoTotal[0] = data.servicoTotal[0];

        servicoTotal[1] = data.servicoTotal[1];

        servicoTotal[2] = data.servicoTotal[2];

        servicoTotal[3] = data.servicoTotal[3];

        servicoTotal[4] = data.servicoTotal[4];

        servicoTotal[5] = data.servicoTotal[5];

        servicoTotal[6] = data.servicoTotal[6];



        UP_NVL_lucroServico[0] = data.UP_NVL_lucroServico[0];

        UP_NVL_lucroServico[1] = data.UP_NVL_lucroServico[1];

        UP_NVL_lucroServico[2] = data.UP_NVL_lucroServico[2];

        UP_NVL_lucroServico[3] = data.UP_NVL_lucroServico[3];

        UP_NVL_lucroServico[4] = data.UP_NVL_lucroServico[4];

        UP_NVL_lucroServico[5] = data.UP_NVL_lucroServico[5];

        UP_NVL_lucroServico[6] = data.UP_NVL_lucroServico[6];



        multiplicadorServico[0] = data.multiplicadorServico[0];

        multiplicadorServico[1] = data.multiplicadorServico[1];

        multiplicadorServico[2] = data.multiplicadorServico[2];

        multiplicadorServico[3] = data.multiplicadorServico[3];

        multiplicadorServico[4] = data.multiplicadorServico[4];

        multiplicadorServico[5] = data.multiplicadorServico[5];

        multiplicadorServico[6] = data.multiplicadorServico[6];



        UP_NVL_duracaoServico[0] = data.UP_NVL_duracaoServico[0];

        UP_NVL_duracaoServico[1] = data.UP_NVL_duracaoServico[1];

        UP_NVL_duracaoServico[2] = data.UP_NVL_duracaoServico[2];

        UP_NVL_duracaoServico[3] = data.UP_NVL_duracaoServico[3];

        UP_NVL_duracaoServico[4] = data.UP_NVL_duracaoServico[4];

        UP_NVL_duracaoServico[5] = data.UP_NVL_duracaoServico[5];

        UP_NVL_duracaoServico[6] = data.UP_NVL_duracaoServico[6];



        tempoServico[0] = data.tempoServico[0];

        tempoServico[1] = data.tempoServico[1];

        tempoServico[2] = data.tempoServico[2];

        tempoServico[3] = data.tempoServico[3];

        tempoServico[4] = data.tempoServico[4];

        tempoServico[5] = data.tempoServico[5];

        tempoServico[6] = data.tempoServico[6];



        gerentes[0] = data.gerentes[0];

        gerentes[1] = data.gerentes[1];

        gerentes[2] = data.gerentes[2];

    }
}

   

  


