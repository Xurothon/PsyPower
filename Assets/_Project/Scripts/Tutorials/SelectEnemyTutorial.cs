using UnityEngine;
using DG.Tweening;

public class SelectEnemyTutorial : MonoBehaviour
{
    [SerializeField] private Vector3 _touchScalePointer;
    [SerializeField] private float _durationScale;
    [SerializeField] private Transform _pointer;
    private Sequence _mySequence;

    private void Start()
    {
        _mySequence = DOTween.Sequence();
        StartTutorial();
    }

    public void StartTutorial()
    {
        _mySequence.Append(_pointer.DOScale(_touchScalePointer, _durationScale))
            .Append(_pointer.DOScale(new Vector3(1f, 1f, 1f), _durationScale).OnComplete(RepeatTutorial));
    }

    public void RepeatTutorial()
    {
        _mySequence.Restart();
    }

    private void OnDisable()
    {
        _mySequence.Kill();
    }
}
