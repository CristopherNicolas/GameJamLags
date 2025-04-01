using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] Image bg;
    [SerializeField] Button startGameButon;

    void Awake()
    {
        startGameButon.onClick.AddListener(()=> {
            Debug.Log("partida iniciada");
            startGameButon.transform.DOPunchScale(Vector3.one * .25f, .75f);
            bg.DOFade(1,1.25f).OnComplete(()=> {
            SceneManager.LoadScene(1);
                                 
            });
        });
    }
}
