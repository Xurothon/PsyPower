using UnityEngine;
using DG.Tweening;

public class RotateForce : PsySphereCollision
{
    private new void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(transform.position, _addVelocity);
        }
        else if (other.GetComponent<Box>())
        {
            other.GetComponent<Box>().AddForceToPoint(transform.position, _addVelocity);
        }
    }
}
