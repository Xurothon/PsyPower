﻿using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    public bool IsHasEnemy => _isHasEnemy;
    public Transform EnemyPos => _enemyPos;
    [SerializeField] private bool _isHasEnemy;
    [SerializeField] private Transform _enemyPos;
    private Rigidbody _rigidbody;
    private Vector3 _oldPosition;
    private Outline _outline;

    public void TakeDamage(Vector3 sphereСenter, float addVelocity)
    {
        _rigidbody.AddForce(Vector3.up * addVelocity / 3, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    public void AddForceToPoint(Vector3 point, float addVelocity)
    {
        TakeDamage(point, addVelocity);
        // _oldPosition = transform.position;
        // Debug.Log("2");
        // Debug.Log(Vector3.up * addVelocity / 3);
        // _rigidbody.AddForce((transform.position - point + Vector3.up).normalized * addVelocity / 2, ForceMode.Impulse);
        // Destroy(gameObject, 5f);
    }

    private void OnMouseUp()
    {
        _outline.enabled = true;
        Helpers.Instance.EnemySelector.AddTransformObject(transform);
    }

    private void OnDisable()
    {
        Helpers.Instance.EnemySelector.RemoveObject(transform);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _outline = GetComponent<Outline>();
    }
}
