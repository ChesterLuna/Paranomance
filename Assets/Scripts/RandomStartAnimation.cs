using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartAnimation : MonoBehaviour
{
    [SerializeField] float offset = 1;

    public void Start()
    {
        Invoke("PlayAnimation", Random.value * offset);

    }

    private void PlayAnimation()
    {
        GetComponent<Animation>().Play();
        if(Random.Range(0,2) == 1)
        {
            transform.parent.GetComponent<RectTransform>().localScale = new Vector2(-1,1);

        }
    }


}
