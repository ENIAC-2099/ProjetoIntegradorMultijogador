using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    public GameObject dano; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().Dano();
            dano.SetActive(true);
            Invoke("DesligarCaixa", 1); 
        }
    }


    public void DesligarCaixa()
    {
        dano.SetActive(false); 
    }
}
