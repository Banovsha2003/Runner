using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private Vector3 stackOffset;


    private void Start()
    {
        StackHolder.Instance.coffeeList.Add(transform.GetChild(0));
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, verticalSpeed) * (speed * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -4.5f, 4.5f),
            transform.position.y,
            transform.position.z);

        FollowStack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.AddComponent<CollectedCoffee>();
            StackHolder.Instance.coffeeList.Add(other.transform);
            
            UIManager.Instance.UpdateCoinValue();
            
            other.tag = "Collected";
            StackHolder.Instance.AnimateCollectables();
        }
    }

    private void FollowStack()
    {
        for (int i = 1; i < StackHolder.Instance.coffeeList.Count; i++)
        {
            Vector3 prevPos = StackHolder.Instance.coffeeList[i - 1].transform.position + stackOffset;
            Vector3 currentPos = StackHolder.Instance.coffeeList[i].transform.position;

            StackHolder.Instance.coffeeList[i].transform.position =
                Vector3.Lerp(currentPos, prevPos, lerpSpeed * Time.deltaTime);
        }
    }
}