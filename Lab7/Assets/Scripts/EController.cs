using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EController : MonoBehaviour
{

    public int moverEnX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D pegar = Physics2D.Raycast(transform.position, new Vector2(moverEnX, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moverEnX, 0) * 4;
        if(pegar.distance < 0.8f)
        {
            if(moverEnX > 0)
            {
                moverEnX = -1;
            }
            else
            {
                moverEnX = 1;
            }

        }

    }
}
