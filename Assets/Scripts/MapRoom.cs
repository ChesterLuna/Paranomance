using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapRoom : MonoBehaviour
{
    //[SerializeField] string sceneToLoad;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }

    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
