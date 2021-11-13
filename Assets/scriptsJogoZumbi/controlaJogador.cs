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

    public bool vivo = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        //Input do Jogador - Guarda as teclas apertadas.
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX,0 ,eixoZ);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

        //Animações do jogador
        if(direcao != Vector3.zero){
            GetComponent<Animator>().SetBool("Mover", true);
    }
        else {
            GetComponent<Animator>().SetBool("Mover",false);
        }

        if(vivo == false && Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("game");
        }
    }
    void FixedUpdate()
    {
        //Movimentação do jogador junto com a fisica.
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin,raio.direction*100, Color.red);

        RaycastHit impacto;

        if( Physics.Raycast(raio,out impacto,100, Mascarachao)){
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = 0;

            Quaternion rotacaoJogador = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(rotacaoJogador);
        }

    }
    
}
