using UnityEngine;

public class PsySphereCollision : MonoBehaviour
{
    [SerializeField] protected float _addVelocity;

    public void IncreaseForce(float value)
    {
        _addVelocity *= value;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().TakeDamage(transform.position, _addVelocity);
        }
        else if (other.GetComponent<Box>())
        {
            other.GetComponent<Box>().AddForceToPoint(transform.position, _addVelocity);
        }
    }
}
