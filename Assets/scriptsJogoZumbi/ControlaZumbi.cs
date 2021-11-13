using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        
        float distancia = Vector3.Distance(transform.position,Jogador.transform.position);// calcula a distancia entre dois elementos
            
        Vector3 direcao = Jogador.transform.position - transform.position;  // direção para percorrer a distancia entre dois elementos.

            // Definindo uma variavel de rotação que olhara para a direção de aonde estas nosso player. 
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

            //Fazer a fisica rotacionar o boneco com base na variavel definida,sobre a direção do player.
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if (distancia>2.5 &&  distancia <20){

            //O mover o personagem pela fisica (Daonde a fisica deixou ele + a direção que ele deve ir normalizada, para igualar a o movimento, *velocidade do zumbi *Time.deltaTime, para deixar mais liso)
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized*Velocidade*Time.deltaTime);
            GetComponent<Animator>().SetBool("PertoPlayer",true);
            GetComponent<Animator>().SetBool("Atacando",false);
        }    
        else if (distancia<=2.5)
        {
            GetComponent<Animator>().SetBool("Atacando",true);
        }
        else if (distancia>=20){
            GetComponent<Animator>().SetBool("PertoPlayer",false );

        }
    } 

    void AtacaJogador(){
        Time.timeScale = 0;
        Jogador.GetComponent<controlaJogador>().TextoGamerOver.SetActive(true);
    }
}
