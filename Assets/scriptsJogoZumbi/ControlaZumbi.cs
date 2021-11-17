using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    private Rigidbody rigidbodyZumbi;
    private Animator animatorZumbi;
    private MovimentoPersonagem movimentoInimigo;
    
    public AudioSource audioSourceZumbi;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        int geraTipoZumbi = Random.Range(1,28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

        rigidbodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
        movimentoInimigo = GetComponent<MovimentoPersonagem>();

        int barulho = Random.Range(1,6);

       audioSourceZumbi.Play();
    }

    void FixedUpdate(){
        
        float distancia = Vector3.Distance(transform.position,Jogador.transform.position);// calcula a distancia entre dois elementos
            
        Vector3 direcao = Jogador.transform.position - transform.position;  // direção para percorrer a distancia entre dois elementos.

            // Definindo uma variavel de rotação que olhara para a direção de aonde estas nosso player. 
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

            //Fazer a fisica rotacionar o boneco com base na variavel definida,sobre a direção do player.
       rigidbodyZumbi.MoveRotation(novaRotacao);

        if (distancia>3 && distancia < 25 ){

            //O mover o personagem pela fisica (Da onde a fisica deixou ele + a direção que ele deve ir normalizada, para igualar a o movimento, *velocidade do zumbi *Time.deltaTime, para deixar mais liso)
           movimentoInimigo.Movimentar(direcao, Velocidade);
           
            animatorZumbi.SetBool("Atacando",false);
            animatorZumbi.SetBool("PertoPlayer", true);
        }    
        else if (distancia<=3)
        {
            animatorZumbi.SetBool("Atacando",true);
        }
        else if (distancia >= 25 ){
            animatorZumbi.SetBool("PertoPlayer", false);
        }
    }
        

    void AtacaJogador(){
       // Time.timeScale = 0;
       // Jogador.GetComponent<controlaJogador>().TextoGamerOver.SetActive(true);
       //  Jogador.GetComponent<controlaJogador>().vivo = false;

        int dano = Random.Range(10,21);
       Jogador.GetComponent<controlaJogador>().TomarDano(dano);
    }
}