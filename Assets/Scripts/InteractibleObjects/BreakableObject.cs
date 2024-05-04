using UnityEngine;

public abstract class BreakableObject : MonoBehaviour
{
    [SerializeField] internal string usableTool;
    [SerializeField] internal float health;
    [SerializeField] internal GameObject particles;
    [SerializeField] internal Transform particlesTransform;

     internal bool isPossibleToGet = false;

    private void OnMouseEnter()
    {
        isPossibleToGet = true;
    }

    private void OnMouseExit()
    {
        isPossibleToGet = false;
    }
}
