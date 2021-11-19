using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacacaoPersonagem : MonoBehaviour
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
}
