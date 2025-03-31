using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool puedeAbrir = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("Has entrado en rangoo de la puerta, presioona Espacio para abrirla");
            puedeAbrir = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
         if(other.CompareTag("Player")){
            Debug.Log("Has salido del rangoo de la puerta");
            puedeAbrir = false;

        }
    }
}
