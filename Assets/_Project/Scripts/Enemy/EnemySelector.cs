using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    public List<Transform> ObjectTransforms { get; private set; }
    public bool IsEmpty { get { return ObjectTransforms.Count == 0; } }

    public void AddTransformObject(Transform objectTransform)
    {
        ObjectTransforms.Add(objectTransform);
        if (objectTransform.gameObject.TryGetComponent(out Box box))
        {
            if (box.IsHasEnemy)
            {
                ObjectTransforms.Add(box.EnemyPos);
            }
        }
    }

    public Transform GetObjectTransform()
    {
        Transform temp = ObjectTransforms[0];
        ObjectTransforms.RemoveAt(0);
        return temp;
    }

    public void RemoveObject(Transform objectTransform)
    {
        if (ObjectTransforms.Contains(objectTransform))
        {
            ObjectTransforms.Remove(objectTransform);
        }
    }

    private void Awake()
    {
        ObjectTransforms = new List<Transform>();
    }
}
