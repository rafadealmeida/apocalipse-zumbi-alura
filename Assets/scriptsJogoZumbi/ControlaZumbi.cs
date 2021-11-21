using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour, Imatavel
{
    public GameObject Jogador;
    public float Velocidade = 5;
    private MovimentoPersonagem movimentoInimigo;
    private AnimacaoPersonagem animacaoInimigo;
    private Status statusZumbi;
    public AudioClip MorteZumbi;
    
    public AudioSource audioSourceZumbi;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag(Tags.Jogador);
        ZumbiAleatorio();

        movimentoInimigo = GetComponent<MovimentoPersonagem>();
        animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        statusZumbi = GetComponent<Status>();

        int barulho = Random.Range(1,6);

       audioSourceZumbi.Play();
    }

    void FixedUpdate(){
        
        float distancia = Vector3.Distance(transform.position,Jogador.transform.position);// calcula a distancia entre dois elementos
            
        Vector3 direcao = Jogador.transform.position - transform.position;  // direção para percorrer a distancia entre dois elementos.

            // Definindo uma variavel de rotação que olhara para a direção de aonde estas nosso player. 

            movimentoInimigo.Rotacionar(direcao);

        if (distancia>3 && distancia < 25 ){

            //O mover o personagem pela fisica (Da onde a fisica deixou ele + a direção que ele deve ir normalizada, para igualar a o movimento, *velocidade do zumbi *Time.deltaTime, para deixar mais liso)
           movimentoInimigo.Movimentar(direcao, statusZumbi.Velocidade);
           
            animacaoInimigo.Atacar(false);
            animacaoInimigo.PertoPlayer(true);
            
        }    
        else if (distancia<=3)
        {
            animacaoInimigo.Atacar(true);
            
        }
        else if (distancia >= 25 ){
            animacaoInimigo.PertoPlayer(false);
            
        }
    }
        

    void AtacaJogador(){
       // Time.timeScale = 0;
       // Jogador.GetComponent<controlaJogador>().TextoGamerOver.SetActive(true);
       //  Jogador.GetComponent<controlaJogador>().vivo = false;

        int dano = Random.Range(10,21);
       Jogador.GetComponent<controlaJogador>().TomarDano(dano);
    }
    void ZumbiAleatorio(){
          int geraTipoZumbi = Random.Range(1,28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    public void TomarDano(int dano){
        statusZumbi.Vida -=dano;
        if(statusZumbi.Vida<=0){
            Morrer();
        }
    }
    public void Morrer(){
        Destroy(gameObject);
        ControlaAudio.instance.PlayOneShot(MorteZumbi);
    }
}