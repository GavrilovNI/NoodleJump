using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 3;

    private Vector2 JumpVector => transform.up;

    private bool ShouldJump(Collision2D collision)
    {
        return collision.relativeVelocity.y <= 0;
    }

    private void ApplyJump(Collision2D collision, Rigidbody2D rigidbody)
    {
        Vector2 velocityProjecton = Vector2.Dot(JumpVector, rigidbody.velocity) * rigidbody.velocity.normalized;

        Vector2 newVelocity = rigidbody.velocity - velocityProjecton + JumpVector * _velocity;

        rigidbody.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D jumperRigidbody = collision.transform.GetComponent<Rigidbody2D>();
        if(jumperRigidbody == null)
            return;

        if(ShouldJump(collision))
            ApplyJump(collision, jumperRigidbody);
    }
}
