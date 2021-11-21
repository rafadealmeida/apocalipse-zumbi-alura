using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour, Imatavel
{
    public GameObject Jogador;
    public float Velocidade = 5;
    public AudioClip MorteZumbi;
    public AudioSource audioSourceZumbi;

    private MovimentoPersonagem movimentoInimigo;
    private AnimacaoPersonagem animacaoInimigo;
    private Status statusZumbi;
    private Vector3 posicaoAleatoria;7
    private Vector3 posicao;
    private float contadorVagar;
    private float tempoEntrePosicoesAleatorias;

    

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
            
        // direção para percorrer a distancia entre dois elementos.

            // Definindo uma variavel de rotação que olhara para a direção de aonde estas nosso player. 

            movimentoInimigo.Rotacionar(direcao);

        if (distancia>3 && distancia < 25 ){

            //O mover o personagem pela fisica (Da onde a fisica deixou ele + a direção que ele deve ir normalizada, para igualar a o movimento, *velocidade do zumbi *Time.deltaTime, para deixar mais liso)
            movimentoInimigo.Movimentar(direcao, statusZumbi.Velocidade);

            direcao = Jogador.transform.position - transform.position; 

            animacaoInimigo.Atacar(false);
            animacaoInimigo.PertoPlayer(true);
            
        }    
        else if (distancia<=3)
        {
            animacaoInimigo.Atacar(true);
            
        }
        else if (distancia >= 25 ){
            Vagar();
            animacaoInimigo.Vagart(true);
            
        }
        else {
            animacaoInimigo.Vagart(false);
            animacaoInimigo.PertoPlayer(false);
            
        }
    }

     void Vagar(){

         contadorVagar -=Time.deltaTime;
         if (contadorVagar<=0){
            posicaoAleatoria = AleatorizarPosição()
            contadorVagar +=tempoEntrePosicoesAleatorias;
         }

            direcao = posicaoAleatoria - transform.position; 
        movimentoInimigo.Movimentar(direcao, statusZumbi.Velocidade);

     }   

     Vector3 AleatorizarPosição(){ //metodo do estilo vector3 para gerar um posição aleatoria e retornar essa posição.
         Vector3 posicao =Random.insideUnitSphere*10; //gera uma esfera de raio 10, neste caso, e dentro dessa esfera ira randorizar um posição.
         posicao += transform.position;
         posicao.y=0;

         return posicao;
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