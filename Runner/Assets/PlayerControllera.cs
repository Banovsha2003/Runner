using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControllera : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layer;

    private Vector3 _direction;
    private Rigidbody _physics;
    private Animator _animator;
    private float Score;
    private float coinCount=0f;
   

    void Start()
    {
        _physics = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        transform.localPosition += _direction * speed * Time.deltaTime;

        transform.localPosition =
            new Vector3(
                Mathf.Clamp(transform.localPosition.x, -5f, 5f),
                transform.localPosition.y,
                transform.localPosition.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
            _physics.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        if(other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
            coinCount++;
            UIManager.Instance.UpdateCoinValue(coinCount);
            Debug.Log("Coins:"+ coinCount);
        }
        if(other.gameObject.tag=="Bag")
        {
            Restart();
        }
        if(other.gameObject.tag=="Finish")
        {
            speed = 0;
        }
    }

    private void Restart()
    {
        throw new NotImplementedException();
    }
}
