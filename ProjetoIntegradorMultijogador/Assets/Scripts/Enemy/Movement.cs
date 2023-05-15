using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Movement : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform[] destino;
    public int pontoAtual;
    public float distanciaAceitavel = 1;
    public float velocidadePadrao = 10;
    public GameObject player; 
    
    void Update()
    {
        
        //pega a distancia entre dois pontos. 
        float distancia = Vector3.Distance(transform.position,
            destino[pontoAtual].position);

        //se a distancia for menor que a aceitavel
        //vamos para o proximo ponto.
        if (distancia < distanciaAceitavel)
        {
            pontoAtual++;
            if (pontoAtual >= destino.Length)
            {
                pontoAtual = 0;
            }
        }

        agente.SetDestination(destino[pontoAtual].position);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("encontrei o player");
            agente.SetDestination(player.transform.position);
        }
	}

}
