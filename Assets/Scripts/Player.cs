using System.Linq;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float intensidadModoCiego = 0.2f;
    public bool modoCiego = false,canMove = true;
    public float speed = 5f,rotationSpeed = 10f;
    [SerializeField] InputActionReference move, cambiar, interactuar;
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject personajeCiego,personajeSinSentimientos;
    [SerializeField] CinemachineCamera camara;
    [SerializeField] Image panelVision;


    void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
        
        //agregar a todas las luces su intensidad al nombre
        FindObjectsByType<Light>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList().ForEach(l => l.name+=$":{l.intensity}");

        cambiar.action.started += (cntx)=>{
          //cambio de persoonaje aqui;
          //quiza cambiar la posicion con DoTween;  
          modoCiego = !modoCiego;
          Debug.Log($"Cambio de personaje y modo a ciego : {modoCiego}"); 
          var luces = FindObjectsByType<Light>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
          if(modoCiego){
            //bajar todas las luces con dotween
            luces.ForEach(l => l.intensity = intensidadModoCiego);
            
          }
          else{
            //subir todas las luces con dotween
            luces.ForEach(l => {
                float val = float.Parse( l.name.Split(":")[1]);
                l.intensity = val;
            });
          }
          //cambio de camara
          camara.Follow = modoCiego? personajeCiego.transform : personajeSinSentimientos.transform;
          //cambio en la pantalla 
            panelVision.DOFade(modoCiego? .95f:0, .45f);
             //UNPARENT TEMPOORALMENTE
            personajeCiego.transform.parent = null;
            Vector3 posCiego = personajeCiego.transform.position, posSinSentimientos = personajeSinSentimientos.transform.position;
            canMove = false;
            personajeCiego.transform.DOMove(posSinSentimientos,.45f);
            personajeSinSentimientos.transform.DOMove(posCiego,.45f).OnComplete(()=>{
                personajeCiego.transform.parent = personajeSinSentimientos.transform;
                canMove = true;
            });
        };

    }
    void Update()
    {
        Vector2 moveVector = move.action.ReadValue<Vector2>();

        if (moveVector != Vector2.zero && canMove)
        {
            Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y).normalized;
            controller.Move(moveDirection * speed * Time.deltaTime);
              
            // Calculamos la rotación deseada
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            
            // Interpolamos suavemente hacia la nueva rotación
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            //aplicar animacion de movimiento aqui
            //aplicar sonido de movimiento aqui
        }
    }
}
