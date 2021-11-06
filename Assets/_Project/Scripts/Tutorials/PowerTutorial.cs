using UnityEngine;
using DG.Tweening;

public class PowerTutorial : MonoBehaviour
{
    [SerializeField] private Vector3 _touchScalePointer;
    [SerializeField] private float _durationScale;
    [SerializeField] private Transform _pointer;
    [SerializeField] private Transform _startPositionPointer;
    [SerializeField] private Transform _endPositionPointer;
    [SerializeField] private float _durationSpeed;
    private Sequence _mySequence;

    private void Start()
    {
        _mySequence = DOTween.Sequence();
        StartTutorial();
    }

    public void StartTutorial()
    {
        _pointer.position = _startPositionPointer.position;
        _mySequence.Append(_pointer.DOScale(_touchScalePointer, _durationScale))
            .Append(_pointer.DOMove(_endPositionPointer.position, _durationSpeed))
            .Append(_pointer.DOScale(new Vector3(1f, 1f, 1f), _durationScale).OnComplete(RepeatTutorial));
    }

    public void RepeatTutorial()
    {
        _pointer.position = _startPositionPointer.position;
        _mySequence.Restart();
    }

    private void OnDisable()
    {
        _mySequence.Kill();
    }
}
