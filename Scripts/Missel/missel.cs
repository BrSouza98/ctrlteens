using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missel : MonoBehaviour
{
    Transform alvo;

    Rigidbody2D corpo;

    TrailRenderer trail;

    public float velocidade;

    public float rotacao;

    public float tempoVida;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        corpo = GetComponent<Rigidbody2D>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    void DestroyMissile()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        trail.enabled = false;
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missil"))
        {
            DestroyMissile();
        }
    }

    void FixedUpdate()
    {
        if (tempoVida > 0f)
        {
            if(alvo != null)
            {
                Vector2 direction = (Vector2)alvo.position - corpo.position;

                direction.Normalize();

                float rotateAmout = Vector3.Cross(direction, transform.up).z;

                corpo.angularVelocity = rotateAmout * rotacao;

                corpo.velocity = transform.up * velocidade;
            }
        }

        else
        {
            DestroyMissile();
        }
          
        tempoVida -= Time.deltaTime;
    }





    // Update is called once per frame
    void Update()
    {
        
    }


}
