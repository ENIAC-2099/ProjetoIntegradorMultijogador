using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class fogueira : MonoBehaviour
{
    public Slider rituais;
    [SerializeField] float howMany; 

    void Start()
    {
        howMany = rituais.maxValue; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cursed")
        {
            rituais.value += 1;
            Destroy(other.gameObject);
        }
    }
}
