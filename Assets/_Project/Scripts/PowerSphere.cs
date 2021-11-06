using UnityEngine;

public class PowerSphere : MonoBehaviour
{
    public SphereCollider SphereCollider { get { return _sphereCollider; } }
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private PsySphereCollision _psySphereCollision;

    public void IncreaseAbility(float addRadius, float addForce)
    {
        SphereCollider.radius += addRadius;
        _psySphereCollision.IncreaseForce(1 + addForce);
    }
}
