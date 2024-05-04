using UnityEngine;

public abstract class InteractibleObject : MonoBehaviour
{
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
