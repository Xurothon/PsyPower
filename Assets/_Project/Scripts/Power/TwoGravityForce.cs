using UnityEngine;
public class TwoGravityForce : PsySphereCollision
{
    private System.Collections.Generic.List<Enemy> _enemies;
    private System.Collections.Generic.List<Vector3> _enemyPosition;

    private new void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().AddForceToPoint(transform.position, _addVelocity);
            _enemies.Add(other.GetComponent<Enemy>());
            _enemyPosition.Add(other.transform.position);
            this.Wait(0.4f, () => TakeEnemyDamage());
        }
        else if (other.GetComponent<Box>())
        {
            other.GetComponent<Box>().AddForceToPoint(transform.position, _addVelocity);
            this.Wait(0.4f, () => other.GetComponent<Box>().TakeDamage(transform.position, _addVelocity));
        }
    }

    private void Awake()
    {
        _enemies = new System.Collections.Generic.List<Enemy>();
        _enemyPosition = new System.Collections.Generic.List<Vector3>();
    }

    private void TakeEnemyDamage()
    {
        while (_enemies.Count > 0)
        {
            _enemies[0].TakeDamage(transform.position, _enemyPosition[0], _addVelocity);
            _enemies.RemoveAt(0);
            _enemyPosition.RemoveAt(0);
        }
    }
}
