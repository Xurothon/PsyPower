using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Enemy))]
public class EnemyOutlineTutorial : EnemyOutline
{
    private void OnMouseUp()
    {
        if (_enemy.IsActive && !_enemy.IsDie)
        {
            _outline.enabled = true;
            Helpers.Instance.EnemySelector.AddTransformObject(transform);
            Tutorial.Instance.CompleteFirstTutorial();
        }
    }
}
