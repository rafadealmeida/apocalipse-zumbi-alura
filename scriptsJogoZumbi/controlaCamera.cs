using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaCamera : MonoBehaviour
{
    public GameObject Jogador;

    Vector3 distaciaCamera;

    // Start is called before the first frame update
    void Start()
    {
        distaciaCamera = transform.position - Jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Jogador.transform.position + distaciaCamera;
    }
}
