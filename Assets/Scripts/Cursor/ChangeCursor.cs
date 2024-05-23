using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorDefault;
    [SerializeField] private Texture2D cursorChanged;
    void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorChanged, Vector2.zero, CursorMode.ForceSoftware);
        Debug.Log("Бью");
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
        Debug.Log("Не бью!!!!!!!!!!!!!");
    }
}
