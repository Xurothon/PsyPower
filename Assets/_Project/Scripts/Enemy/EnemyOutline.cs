using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Enemy))]
public class EnemyOutline : MonoBehaviour
{
    protected Outline _outline;
    protected Enemy _enemy;

    private void OnMouseUp()
    {
        if (_enemy.IsActive && !_enemy.IsDie)
        {
            _outline.enabled = true;
            Helpers.Instance.EnemySelector.AddTransformObject(transform);
        }
    }

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _enemy = GetComponent<Enemy>();
    }
}
