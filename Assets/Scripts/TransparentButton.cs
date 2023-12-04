using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }

}
