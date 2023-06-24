using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Ritual : MonoBehaviour
{
    public GameObject[] cursedObjects;
    public Slider progressBar;
    public Image v;
    public GameObject postProcessing;
    public GameObject capelobo;

    void Start()
    {
        progressBar.maxValue = cursedObjects.Length;
        progressBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //condição de vitória. 
        if(progressBar.value == progressBar.maxValue)
        {
            v.enabled = true;
            postProcessing.SetActive(true);
            Destroy(capelobo);
            Invoke("Vitoria", 3); 
        }
    }

    void Vitoria()
    {
        SceneManager.LoadScene("Menu");       
    }
}
