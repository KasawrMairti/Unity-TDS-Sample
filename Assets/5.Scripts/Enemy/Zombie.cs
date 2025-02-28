using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IDamagable
{
    [SerializeField] private float moveSpeed = 5.0f;
    private int lineCur;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        lineCur = Random.Range(0, 2);

        if (lineCur == 0) gameObject.layer = 1 << LayerMask.NameToLayer("FirstLine");
        else if (lineCur == 1) gameObject.layer = 1 << LayerMask.NameToLayer("SecondLine");
        else if (lineCur == 2) gameObject.layer = 1 << LayerMask.NameToLayer("ThirdLine");
    }

    private void Update()
    {
        
    }

    private void Move()
    {

    }
    
    private void Jump()
    {

    }

    public void Damaged()
    {
        
    }
}
