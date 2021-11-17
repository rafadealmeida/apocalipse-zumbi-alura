using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    float contadorTempo = 0;
    public float tempoRespawn = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        contadorTempo +=Time.deltaTime;

        if(contadorTempo>= tempoRespawn){
            Instantiate (Zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }
    }
}
