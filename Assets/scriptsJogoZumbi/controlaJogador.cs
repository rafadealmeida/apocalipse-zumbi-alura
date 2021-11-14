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


    private Rigidbody rigidbodyJogador;

    private Animator animatorJogador;

    public int Vida = 100;

   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Input do Jogador - Guarda as teclas apertadas.
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX,0 ,eixoZ);
       rigidbodyJogador.MovePosition(rigidbodyJogador.position + (direcao * Velocidade * Time.deltaTime));

        //Animações do jogador
        if(direcao != Vector3.zero){
            animatorJogador.SetBool("Mover", true);
    }
        else {
            animatorJogador.SetBool("Mover",false);
        }

        if(Vida <= 0 && Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("game");
        }
    }
    void FixedUpdate()
    {
        //Movimentação do jogador junto com a fisica.
        rigidbodyJogador.MovePosition(rigidbodyJogador.position + (direcao * Velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin,raio.direction*100, Color.red);

        RaycastHit impacto;

        if( Physics.Raycast(raio,out impacto,100, Mascarachao)){
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = 0;

            Quaternion rotacaoJogador = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbodyJogador.MoveRotation(rotacaoJogador);
        }

    }

    public void TomarDano(int dano)
    {
        Vida -= dano;

        if(Vida <= 0){
            Time.timeScale = 0;
            TextoGamerOver.SetActive(true);
        }
    }
    
}
