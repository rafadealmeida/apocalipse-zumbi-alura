using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaJogador : MonoBehaviour
{
    public float Velocidade = 10;

    Vector3 direcao;

    public LayerMask Mascarachao;

    // Start is called before the first frame update
    void Start()
    {
        
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