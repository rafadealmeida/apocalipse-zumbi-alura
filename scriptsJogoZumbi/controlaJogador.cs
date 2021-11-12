using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaJogador : MonoBehaviour
{
    public float Velocidade = 10;

    Vector3 direcao;

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
    }
    
}
