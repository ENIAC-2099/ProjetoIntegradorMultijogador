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
    [SerializeField] int perseguicao;
    [SerializeField] GameObject playerPrefab;
    public AudioSource cry;  
    
    void Update()
    {
        switch (perseguicao)
        {
            case 1:
                Debug.Log("Achei o Player");

                if (playerPrefab != null)
                {
                    agente.SetDestination(playerPrefab.transform.position);
                }
                break;

            default:
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
                break;
        }  
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            playerPrefab = other.gameObject;
            perseguicao = 1;
            cry.Play(); 
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerPrefab)
        {
            playerPrefab = other.gameObject;
            cry.Pause();
            perseguicao = 0;
        }
    }

}
