using UnityEngine;

public class Tornado : PsySphereCollision
{
    // [SerializeField] private Transform _tornadoCenter;
    // [SerializeField] private float _refreshRate;
    // private System.Collections.Generic.List<Enemy> _enemies;
    // private System.Collections.Generic.List<Vector3> _enemyPosition;
    // private new void OnTriggerEnter(Collider other)
    // {
    //     _particleSystem.Play();
    //     if (other.GetComponent<Enemy>())
    //     {
    //         _enemies.Add(other.GetComponent<Enemy>());
    //         other.GetComponent<Enemy>().AddForceToPoint(_tornadoCenter.position, _addVelocity);
    //         _enemyPosition.Add(other.transform.position);
    //         this.Wait(1f, () =>
    //         {
    //             StopAllCoroutines();
    //             other.GetComponent<Enemy>().DisableRagdoll();
    //         }
    //             );
    //         this.Wait(3f, () => TakeEnemyDamage());
    //     }
    //     else if (other.GetComponent<Friend>())
    //     {
    //         Destroy(other.gameObject);
    //         Helpers.Instance.UIHelper.ActiveGameOverPanel();
    //     }
    //     else if (other.GetComponent<Box>())
    //     {
    //         StartCoroutine(ChangeBoxGravity(other));
    //         this.Wait(3f, () => other.GetComponent<Box>().TakeDamage(transform.position, _addVelocity));
    //     }
    // }

    // private System.Collections.IEnumerator ChangeBoxGravity(Collider other)
    // {
    //     other.GetComponent<Box>().AddForceToPoint(transform.position, _addVelocity);
    //     yield return _refreshRate;
    //     StartCoroutine(ChangeBoxGravity(other));
    // }

    // private void Awake()
    // {
    //     _enemies = new System.Collections.Generic.List<Enemy>();
    //     _enemyPosition = new System.Collections.Generic.List<Vector3>();
    // }

    // private void TakeEnemyDamage()
    // {
    //     while (_enemies.Count > 0)
    //     {
    //         _enemies[0].TakeDamage(transform.position, _enemyPosition[0], _addVelocity);
    //         _enemies.RemoveAt(0);
    //         _enemyPosition.RemoveAt(0);
    //     }
    // }

    // private void OnDisable()
    // {
    //     StopAllCoroutines();
    // }
    [SerializeField] private Transform _tornadoCenter;
    [SerializeField] private float _refreshRate;
    private System.Collections.Generic.List<Enemy> _enemies;
    private System.Collections.Generic.List<Vector3> _enemyPosition;
    private new void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            _enemies.Add(other.GetComponent<Enemy>());
            _enemyPosition.Add(other.transform.position);
            StartCoroutine(ChangeEnemyGravity(other));
            this.Wait(2.5f, () => TakeEnemyDamage());
        }
        else if (other.GetComponent<Box>())
        {
            StartCoroutine(ChangeBoxGravity(other));
            this.Wait(2f, () => other.GetComponent<Box>().TakeDamage(transform.position, _addVelocity));
        }
    }

    private System.Collections.IEnumerator ChangeEnemyGravity(Collider other)
    {
        other.GetComponent<Enemy>().AddForceToPoint(_tornadoCenter.position, _addVelocity);
        yield return _refreshRate;
        StartCoroutine(ChangeEnemyGravity(other));
    }

    private System.Collections.IEnumerator ChangeBoxGravity(Collider other)
    {
        other.GetComponent<Box>().AddForceToPoint(transform.position, _addVelocity);
        yield return _refreshRate;
        StartCoroutine(ChangeBoxGravity(other));
    }

    private void Awake()
    {
        _enemies = new System.Collections.Generic.List<Enemy>();
        _enemyPosition = new System.Collections.Generic.List<Vector3>();
    }

    private void TakeEnemyDamage()
    {
        StopAllCoroutines();
        while (_enemies.Count > 0)
        {
            _enemies[0].TakeDamage(transform.position, _enemyPosition[0], _addVelocity);
            _enemies.RemoveAt(0);
            _enemyPosition.RemoveAt(0);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
