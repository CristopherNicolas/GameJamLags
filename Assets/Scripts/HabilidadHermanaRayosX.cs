using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class HabilidadHermanaRayosX : MonoBehaviour
{
   //ver atraves de las paredes, ver fuentes electricas mas intensamente con cd con decremento, al llegar a 0 se acaba)
   public float cd = 10;
   public InputActionReference habilidadAction;
    void Awake()=> habilidadAction.action.started+= (cntxt) => Habilidad();
    public void Habilidad(){
    if(cd < 10 || !Player.instance.modoCiego) return; 
    cd = 0;
    print("habilidad rayos x cor comenzada");
    StartCoroutine(HabilidadReduccion());
    }
        IEnumerator HabilidadReduccion()
        {
            var objetosAfectados = GameObject.FindGameObjectsWithTag("visonXRay").ToList();
            //a todos los objetos con el tag visionXRay, cambiar su color  y disminuir su alfa del material
            var renderers = from obj in objetosAfectados select obj.GetComponent<Renderer>();
            var materiales = renderers.Select(r => r.material).ToList();
            Debug.Log($"comenzanod habilidad para {materiales.Count} materiales");
            for (float i = 1; i > 0; i-= 0.01f)
            {
                for (int j = 0; j <materiales.Count; j++)
                {
                    materiales[j].color = new Color(materiales[j].color.r, materiales[j].color.g, materiales[j].color.b, i);
                    Debug.Log($"mat {materiales[j].name}  coolor -> {materiales[j].color.ToString()}");
                }
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(5);
            for (float i = 0; i < 1; i+= 0.01f)
            {
                for (int j = 0; j <materiales.Count; j++)
                {
                    materiales[j].color = new Color(materiales[j].color.r, materiales[j].color.g, materiales[j].color.b, i);
                    Debug.Log($"mat {materiales[j].name}  coolor -> {materiales[j].color.ToString()}");
                }
                yield return new WaitForSeconds(0.02f);
            }
            yield break;
        }
    void Update()
    {
        cd += Time.deltaTime;
    }
}
