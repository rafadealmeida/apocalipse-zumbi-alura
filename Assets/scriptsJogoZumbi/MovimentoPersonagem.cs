using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem: MonoBehaviour
{
    private Rigidbody  meuRigidbody;
    void Awake(){
        meuRigidbody = GetComponent<Rigidbody>();
    }


    public void Movimentar(Vector3 direcao, float velocidade){
          meuRigidbody.MovePosition(GetComponent<Rigidbody>().position + direcao.normalized*velocidade*Time.deltaTime);
    }

}
