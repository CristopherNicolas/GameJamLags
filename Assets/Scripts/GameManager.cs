using System;
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
        Vector3 sizePiso = piso.GetComponent<Collider>().bounds.size;
        Vector3 sizePared = paredConPuerta.GetComponent<Collider>().bounds.size;
            for (int i = 0; i < length; i++)
            {

                //crear piso primeroo:
                Vector3 posSpawnPiso = new Vector3(piso.transform.position.x+ i * 10, 
                piso.transform.position.y
                ,piso.transform.position.z);
                
                var tmpPiso = Instantiate(piso);
            }
    }

    public void ComenzarDenuevo()=> segundos = 180; 

     
}
