using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{

    private bool verDerecha = false;
    private float moverX;
    public Sprite nuevo;
    private bool power = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverJugador();
    }

    void MoverJugador()
    {
        moverX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < 0.5f)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1250);
            }

        }

        if(moverX < 0.0f && verDerecha == false)
        {
            CambiarVista();
        } else if(moverX > 0.0f && verDerecha == true)
        {
            CambiarVista();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moverX * 10, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void CambiarVista()
    {
        verDerecha = !verDerecha;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().sprite = nuevo;
            GetComponent<Transform>().localScale = new Vector2(1.8f, 1.5f);
            power = true;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            if (power == true)
            {
                Destroy(collision.gameObject);
            } else if(power == false)
            {
                Destroy(gameObject);
            }

        }
    }



}
