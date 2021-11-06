using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BoxCollider))]
[RequireComponent(typeof(EnemyMove), typeof(RagdollControl))]
[RequireComponent(typeof(Outline))]
public class Enemy : MonoBehaviour
{
    public bool IsDie { get; private set; }
    public bool IsActive { get; private set; }
    [SerializeField] private Rigidbody _forceRigidbody;
    private Step _currentStep;
    private EnemyMove _enemyMove;
    private RagdollControl _ragdollControl;
    private Animator _animator;
    private BoxCollider _boxCollider;
    private Outline _outline;

    public void TakeDamage(Vector3 sphereСenter, float addVelocity)
    {
        TakeDamage(sphereСenter, transform.position, addVelocity);
    }

    public void TakeDamage(Vector3 sphereСenter, Vector3 enemyPosition, float addVelocity)
    {
        if (!IsDie)
        {
            MakePhysical();
        }
        _forceRigidbody.AddForce((new Vector3(enemyPosition.x, enemyPosition.y + 15, enemyPosition.z) - sphereСenter).normalized * addVelocity, ForceMode.Impulse);
        this.Wait(2.5f, () => Die());
    }

    public void AddForceToPoint(Vector3 point, float addVelocity)
    {
        MakePhysical();
        _forceRigidbody.AddForce((point - transform.position).normalized * addVelocity, ForceMode.Impulse);
    }

    public void Die()
    {
        _currentStep.RemoveEnemies(this);
        Destroy(gameObject);
    }

    public void StartMove()
    {
        Active();
        _enemyMove.Move(_currentStep.StartTransform.position);
        _animator.enabled = true;
        _animator.SetTrigger("Walk");
    }

    public void Active()
    {
        IsActive = true;
    }

    public void MakePhysical()
    {
        IsDie = true;
        _animator.enabled = false;
        _boxCollider.enabled = false;
        _enemyMove.StopMove();
        _ragdollControl.MakePhysical();
        _outline.enabled = false;
    }

    public void DisableRagdoll()
    {
        _ragdollControl.Curdle();
    }

    public void SetCurrentStep(Step step)
    {
        _currentStep = step;
    }

    private void Awake()
    {
        _enemyMove = GetComponent<EnemyMove>();
        _ragdollControl = GetComponent<RagdollControl>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _outline = GetComponent<Outline>();
        _forceRigidbody.sleepThreshold = 0.0f;
    }
}
