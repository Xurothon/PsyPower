using UnityEngine;
using System.Collections.Generic;

public class Step : MonoBehaviour
{
    public Transform StartTransform { get { return _startTransform; } }
    public Transform EndTransform { get { return _endTransform; } }
    public Transform NextTransform { get { return _nextTransform; } }
    public bool IsHasEnemy { get { return _currentEnemies.Count > 0; } }
    [SerializeField] private Transform _startTransform;
    [SerializeField] private Transform _endTransform;
    [SerializeField] private Transform _nextTransform;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _enemyTransforms;
    [SerializeField] private bool[] _IsEnemyMove;
    private List<Enemy> _currentEnemies;

    public void RemoveEnemies(Enemy enemy)
    {
        Helpers.Instance.CoinsCounter.AddCoin();
        _currentEnemies.Remove(enemy);
        if (_currentEnemies.Count == 0)
        {
            Helpers.Instance.PositionChanger.SetNextPosition();
        }
    }

    public void ActiveEnemyMoving()
    {
        for (int i = 0; i < _enemyTransforms.Length; i++)
        {
            if (_IsEnemyMove[i])
            {
                _currentEnemies[i].StartMove();
            }
            else
            {
                _currentEnemies[i].Active();
            }

        }
    }

    public void ResetStep()
    {
        RemoveAllEnemies();
        CreateEnemies();
        ActiveEnemyMoving();
    }

    public Transform GetEnemyTransform()
    {
        if (_currentEnemies.Count > 0)
        {
            return _currentEnemies[0].transform;
        }
        return null;
    }

    private void CreateEnemies()
    {
        for (int i = 0; i < _enemyTransforms.Length; i++)
        {
            GameObject enemyObj = Instantiate(_enemy);
            enemyObj.transform.parent = transform;
            enemyObj.transform.position = _enemyTransforms[i].position;
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.SetCurrentStep(this);
            _currentEnemies.Add(enemy);
        }
    }

    private void RemoveAllEnemies()
    {
        while (_currentEnemies.Count > 0)
        {
            Enemy tempEnemy = _currentEnemies[0];
            _currentEnemies.Remove(tempEnemy);
            Destroy(tempEnemy.gameObject);
        }
    }

    private void Awake()
    {
        _currentEnemies = new List<Enemy>();
        CreateEnemies();
    }
}
