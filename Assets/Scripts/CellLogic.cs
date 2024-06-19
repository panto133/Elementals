using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellLogic : MonoBehaviour
{
    [SerializeField]
    private Texture2D attackCursor;
    [SerializeField]
    private Texture2D basicCursor;

    private int x;
    private int y;

    public int xPos { get => x; set => x = value; }
    public int yPos { get => y; set => y = value; }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(attackCursor, new Vector2(0, 0), CursorMode.Auto);
        GetComponent<SpriteRenderer>().color = Color.green;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(basicCursor, new Vector2(0, 0), CursorMode.Auto);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
