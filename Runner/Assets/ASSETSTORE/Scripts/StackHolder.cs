using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackHolder : MonoBehaviour
{
    public List<Transform> coffeeList;
    public static StackHolder Instance { get; private set; }

    private Sequence sequence;

    private void Awake()
    {
        coffeeList = new List<Transform>();

        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AnimateCollectables()
    {
        sequence = DOTween.Sequence();
        sequence.Kill();
        sequence = DOTween.Sequence();
        for (int i = coffeeList.Count - 1; i > 0; i--)
        {
            sequence.Join(coffeeList[i].DOScale(1.5f, 0.1f));
            sequence.AppendInterval(0.05f);
            sequence.Join(coffeeList[i].DOScale(1f, 0.1f));
        }
    }
}