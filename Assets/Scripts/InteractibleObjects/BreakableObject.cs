using UnityEngine;

public abstract class BreakableObject : MonoBehaviour
{
    [SerializeField] internal string usableTool;
    [SerializeField] internal int health;

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
