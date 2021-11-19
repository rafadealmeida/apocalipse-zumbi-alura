using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    public void RotacaoJogador(LayerMask Mascarachao)
    {
          Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin,raio.direction*100, Color.red);

        RaycastHit impacto;

        if( Physics.Raycast(raio,out impacto,100, Mascarachao)){
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = 0;

           Rotacionar(posicaoMiraJogador);
        }
    }
}
