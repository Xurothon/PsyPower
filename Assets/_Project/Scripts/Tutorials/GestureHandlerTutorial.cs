using GestureRecognizer;

public class GestureHandlerTutorial : ExampleGestureHandler
{
    public new void OnRecognize(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty)
        {
            _staffParticle.Play();
            Helpers.Instance.SoundPlayer.PlaySpellClip();
            Helpers.Instance.SphereCreater.CreatePowerSphere(result.gesture.id);
            Tutorial.Instance.CompleteSecondTutorial();
        }
    }
}
