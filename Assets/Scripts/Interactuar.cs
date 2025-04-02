using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactuar : MonoBehaviour
{
    [SerializeField] InputActionReference interactuar;
    void Start()
    {
        interactuar.action.started += (cntxt)=>{
            var puerta = Physics.OverlapSphere(transform.position,2).Where(x => x.GetComponent<Puerta>()).FirstOrDefault();
            if(puerta != null){
                puerta.GetComponent<Puerta>().AbrirOCerrar();
            }

        };
    }
}
