using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{
    public Personaje_basico pj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        pj.puedo_saltar = true;
    }
    void OnTriggerExit(Collider other)
    {
        pj.puedo_saltar = false;
    }
}
