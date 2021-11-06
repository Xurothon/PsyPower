using UnityEngine;
using DG.Tweening;

public class Ball : PsySphereCollision
{
    private void Start()
    {
        Vector3 endPosition = transform.parent.transform.position;
        transform.parent.transform.position = Helpers.Instance.PositionChanger.GetStartPosition();
        transform.parent.transform.DOMove(endPosition, 0.7f);
    }
}
