using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tweentest : MonoBehaviour
{
    public bool isPunch;
    Sequence sequence;

    void Start()
    {
        /*
        transform.DOMoveX(5, 2);
        transform.DORotate(new Vector3(0, 0, 180), 2);
        transform.DOScale(new Vector3(3, 3, 3), 2);
        *//*

        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(5, 2).SetEase(Ease.InBounce));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2).OnComplete(() => { Debug.Log("rotated"); }));
        sequence.Append(transform.DOScale(new Vector3(3,3,3), 2));

        sequence.SetLoops(-1, LoopType.Yoyo);*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPunch)
            {
                isPunch = true;
                transform.DOPunchScale(new Vector3(.5f, .5f, .5f), .1f).OnComplete(() => { isPunch = false; });

                Color color = new(Random.value, Random.value, Random.value);
                Renderer renderer = GetComponent<Renderer>();
                renderer.material.DOColor(color, .1f);
            }
        }
    }
}
