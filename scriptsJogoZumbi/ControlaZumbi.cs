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

        if (distancia>2.5){
            Vector3 direcao = Jogador.transform.position - transform.position;  // direção para percorrer a distancia entre dois elementos.

            //O mover o personagem pela fisica (Daonde a fisica deixou ele + a direção que ele deve ir normalizada, para igualar a o movimento, *velocidade do zumbi *Time.deltaTime, para deixar mais liso)
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized*Velocidade*Time.deltaTime);
            // Definindo uma variavel de rotação que olhara para a direção de aonde estas nosso player. 
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);

            //Fazer a fisica rotacionar o boneco com base na variavel definida,sobre a direção do player.
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }    
    } 
}
