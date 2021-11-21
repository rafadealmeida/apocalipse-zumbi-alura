using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{

    private Animator meuAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        meuAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Atacar(bool estado)
    {
        meuAnimator.SetBool("Atacando",estado);
    }
     public void PertoPlayer(bool estado){
        meuAnimator.SetBool("PertoPlayer", estado);
    }
    public void Movimentar(float valorDeMovimento){
        meuAnimator.SetFloat("Mover",valorDeMovimento);
    }
    public void Andar(bool estado){
        meuAnimator.SetBool("Vagar", estado);
    }

}
