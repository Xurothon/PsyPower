using UnityEngine;

public class EnemySoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _stars;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<Ground>())
        {
            _stars.SetActive(true);
            _audioSource.Play();
        }
    }
}
