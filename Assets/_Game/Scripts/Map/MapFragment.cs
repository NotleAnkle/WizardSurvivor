using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PosDir{
    None = 0,
    NorthWest = 1,
    North = 2,
    NorthEast = 3,
    Center = 4,
    West = 5,
    East = 6,
    SouthWest = 7,
    South = 8,
    SouthEast = 9,
}
public class MapFragment : MonoBehaviour
{
    [SerializeField] private InfinityMapManager mMapManager;
    [SerializeField] private PosDir posDir;

    private float offsetX = 5.6f, offsetY = 9.96f;

    public PosDir Dir => posDir;

    public void SetDir(PosDir dir)
    {
        posDir = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && posDir!= PosDir.Center)
        {
            mMapManager.MapTranform(this);
        }
    }

    #region RePosition
    private void Move(Vector2 centerPos, int x, int y)
    {
        this.transform.position = centerPos + new Vector2(x * offsetX, y * offsetY);
    }

    public void OnNorth(Vector2 centerPos)
    {
        SetDir(PosDir.North);
        Move(centerPos, 0, 1);
    }
    public void OnSouth(Vector2 centerPos)
    {
        SetDir(PosDir.South);
        Move(centerPos, 0, -1);
    }
    public void OnWest(Vector2 centerPos)
    {
        SetDir(PosDir.West);
        Move(centerPos, -1, 0);
    }
    public void OnEast(Vector2 centerPos)
    {
        SetDir(PosDir.East);
        Move(centerPos, 1, 0);
    }
    public void OnNorthWest(Vector2 centerPos)
    {
        SetDir(PosDir.NorthWest);
        Move(centerPos, -1, 1);
    }
    public void OnNorthEast(Vector2 centerPos)
    {
        SetDir(PosDir.NorthEast);
        Move(centerPos, 1, 1);
    }
    public void OnSouthWest(Vector2 centerPos)
    {
        SetDir(PosDir.SouthWest);
        Move(centerPos, -1, -1);
    }
    public void OnSouthEast(Vector2 centerPos)
    {
        SetDir(PosDir.SouthEast);
        Move(centerPos, 1, -1);
    }
    #endregion
}
