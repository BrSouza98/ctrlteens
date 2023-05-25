using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float velocidade;

    public float rotacao;

    Rigidbody2D corpo;



    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        corpo.velocity = transform.up * velocidade;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, SimpleInput.GetAxis("Horizontal") * rotacao);
    }




}
