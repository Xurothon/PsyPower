using UnityEngine;
using GestureRecognizer;

public class ExampleGestureHandler : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _staffParticle;
    public void OnRecognize(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty)
        {
            _staffParticle.Play();
            Helpers.Instance.SoundPlayer.PlaySpellClip();
            Helpers.Instance.SphereCreater.CreatePowerSphere(result.gesture.id);
        }
    }
}
