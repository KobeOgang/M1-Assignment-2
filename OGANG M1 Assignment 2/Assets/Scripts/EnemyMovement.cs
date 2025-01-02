using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool isStunned = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isStunned)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
    }

    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;
            StartCoroutine(StunCoroutine());
        }
    }

    private System.Collections.IEnumerator StunCoroutine()
    {
        isStunned = true;
        yield return new WaitForSeconds(1.5f);
        isStunned = false;
    }

}
