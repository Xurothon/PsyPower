using UnityEngine;

public class GravitySphere : PsySphereCollision
{
    protected new void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.MakePhysical();
            enemy.TakeDamage(other.transform.position, _addVelocity);
            this.Wait(0.5f, () => enemy.AddForceToPoint(new Vector3(other.transform.position.x, -100, other.transform.position.z), _addVelocity * 5));
        }
        else if (other.GetComponent<Box>())
        {
            other.GetComponent<Box>().TakeDamage(transform.position, _addVelocity);
        }
    }
}
