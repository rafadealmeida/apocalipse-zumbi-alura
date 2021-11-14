using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    private controlaJogador scriptControlaJogador;
    public Slider SliderVidaJogador;
    // Start is called before the first frame update
    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<controlaJogador>();

        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizarSliderVidaJogador(){
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }
}
