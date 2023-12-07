using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorDefault;
    [SerializeField] private Texture2D cursorHover;
    [SerializeField] private Texture2D cursorHoverClick;

    public void On_CursorDefault()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

    public void On_CursorHover()
    {
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
    }

    public void On_CursorHoverClick()
    {
        Cursor.SetCursor(cursorHoverClick, Vector2.zero, CursorMode.Auto);
    }
}
