using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje_basico : MonoBehaviour
{
    //para el movimiento del personaje
    public float velocidad_m = 5.0f;
    public float velocidad_r = 200.0f;
    private Animator anim;
    public float x,y;

    //para el salto
    public Rigidbody rb;
    public float fuerza_salto = 8f;
    public bool puedo_saltar;

    //para el ataque del personaje
    public bool estoy_atacando;
    public bool avanzar;
    public float impulso_golpe=10f;




    // Start is called before the first frame update
    void Start()
    {
      puedo_saltar = true;
      anim = GetComponent<Animator>();  

    }

    void FixedUpdate()
    {
      if(!estoy_atacando){
        transform.Rotate(0, x * Time.deltaTime * velocidad_r ,0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidad_m);
      }
      
      if(avanzar)
      {
        rb.velocity = transform.forward * impulso_golpe;
      }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        if(Input.GetKeyDown(KeyCode.Return) && !estoy_atacando)
        {
          anim.SetTrigger("golpeo");
          estoy_atacando = true;
        }

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

      if(puedo_saltar)
      {
        
          if(Input.GetKeyDown(KeyCode.Space))
          {
            anim.SetBool("salte", true);
            rb.AddForce(new Vector3(0, fuerza_salto, 0), ForceMode.Impulse);
          }
        
        
        anim.SetBool("toco_suelo",true);
      }
      else
      {
        estoy_cayendo();
      }
    }
    public void estoy_cayendo()
    {
      anim.SetBool("toco_suelo",false);
      anim.SetBool("salte", false);
    }
    public void dejar_de_golpear()
    {
      estoy_atacando = false;
    }
    public void avanzarSolo()
    {
      avanzar = true;
    }
    public void DejoDeAvanzar()
    {
      avanzar = false;
    }
}

