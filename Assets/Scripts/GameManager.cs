using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GameMaanger : MonoBehaviour
{
   public int segundos = 180;
   public GameObject paredConPuerta,paredSinPuerta,piso;
    IEnumerator Start()
    {
        while(true){
            GenerateCorridor(15);
            while(segundos > 0){
                yield return new WaitForSeconds(1);
                segundos--;
            }     
            yield return new WaitUntil(()=> segundos!=0);
        }
    }

    private void GenerateCorridor(int length)
    {
       Vector3 paredIzquierdaStartPos = paredSinPuerta.transform.position, paredDerechaStartPos = paredConPuerta.transform.position; 
        

        Vector3 sizePiso = piso.GetComponent<Collider>().bounds.size;
        Vector3 sizePared = paredConPuerta.GetComponent<Collider>().bounds.size;

        Debug.Log($"size pared: {sizePared.ToString()}");
            for (int i = 0; i < length; i++)
            {

                //crear piso primeroo:
                Vector3 posSpawnPiso = new Vector3(piso.transform.position.x, 
                piso.transform.position.y
                ,piso.transform.position.z + i * sizePiso.z);
                var tmpPiso = Instantiate(piso, posSpawnPiso,quaternion.identity);
                
                //ahoora la pared izq
                Vector3 posSpawnParedIzquierda = new Vector3(paredIzquierdaStartPos.x,paredIzquierdaStartPos.y,paredIzquierdaStartPos.z + i * sizePared.z);
                bool conPuerta = UnityEngine.Random.Range(0,10) > 5; 
                var tmpParedIzquierda = Instantiate(conPuerta ? paredConPuerta : paredSinPuerta, posSpawnParedIzquierda,quaternion.Euler(270,0,0));
                //pared derecha
                Vector3 posSpawnParedDerecha = new Vector3(paredDerechaStartPos.x,paredDerechaStartPos.y,paredDerechaStartPos.z + i * sizePared.z);
                bool conPuertaDerecha = UnityEngine.Random.Range(0,10) > 5; 
                var tmpParedDerecha = Instantiate(conPuerta ? paredConPuerta : paredSinPuerta, posSpawnParedDerecha,quaternion.Euler(270,0,0));
            }
    }

    public void ComenzarDenuevo()=> segundos = 180; 

     
}
