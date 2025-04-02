using DG.Tweening;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool puedeAbrir, abierta;
    public Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }
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
    public void AbrirOCerrar(){
        if(!puedeAbrir) return;
        if(abierta){
            //cerrrar
            transform.DOLocalRotate(new Vector3(startRotation.x,startRotation.y ,startRotation.z ), .45f);
            abierta = false;
            Debug.Log("abriendo");
        }
        else{
            //cerrrar
            transform.DOLocalRotate(new Vector3(startRotation.x,startRotation.y ,startRotation.z -90), .45f);
            abierta = true;
            Debug.Log("cerrando");
        }
    }
}
