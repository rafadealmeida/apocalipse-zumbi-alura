using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlaJogador : MonoBehaviour
{
    public float Velocidade = 10;

    Vector3 direcao;

    public LayerMask Mascarachao;

    public GameObject TextoGamerOver;

    private MovimentoJogador meuMovimentoJogador;
    private AnimacaoPersonagem animacaoJogador; 

    public int Vida = 100;

    public Interface scriptInterface;

    public AudioClip SomDeDano; 

   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
     
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Input do Jogador - Guarda as teclas apertadas.
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX,0 ,eixoZ);
       
        meuMovimentoJogador.Movimentar(direcao,Velocidade);
        //Animações do jogador

        animacaoJogador.Movimentar(direcao.magnitude);

        if(Vida <= 0 && Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("game");
        }
    }
    void FixedUpdate()
    {
        //Movimentação do jogador junto com a fisica.
        meuMovimentoJogador.Movimentar(direcao,Velocidade);

        meuMovimentoJogador.RotacaoJogador(Mascarachao);

    }

    public void TomarDano(int dano)
    {
        Vida -= dano;

        scriptInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instance.PlayOneShot(SomDeDano);

        if(Vida <= 0){
            Time.timeScale = 0;
            TextoGamerOver.SetActive(true);
        }
    }
    
}