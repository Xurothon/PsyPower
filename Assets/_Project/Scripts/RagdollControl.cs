using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRigidbodies;

    public void MakePhysical()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = false;
        }
    }

    public void MakeKinematic()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = true;
            _allRigidbodies[i].velocity = Vector3.zero;
        }
    }

    public void Curdle()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].useGravity = false;
            _allRigidbodies[i].isKinematic = true;
            _allRigidbodies[i].velocity = Vector3.zero;
        }
    }

    private void Awake()
    {
        MakeKinematic();
    }
}
