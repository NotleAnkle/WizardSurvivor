using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InfinityMapManager : MonoBehaviour
{
    [SerializeField] private List<MapFragment> maps;
    private MapFragment Center;
    private List<MapFragment> mapInfor;
    public void MapTranform(MapFragment fragment)
    {
        PosDir dir = fragment.Dir;
        Center = fragment;
        mapInfor = maps.ToList();
        maps.Clear();
        switch (dir)
        {
            case PosDir.North:
                North();
                break;
            case PosDir.NorthWest:
                NorthWest();
                break;
            case PosDir.NorthEast:
                NorthEast();
                break;
            case PosDir.South:
                South();
                break;
            case PosDir.SouthEast:
                SouthEast();
                break;
            case PosDir.SouthWest:
                SouthWest();
                break;
            case PosDir.East:
                East();
                break;
            case PosDir.West:
                West();
                break;
        }
        SetDir();
    }
    private void North()
    {
        int[] indexs = {6,7,8,0,1,2,3,4,5};
        AddIndex(indexs);
    }

    private void West()
    {
        int[] indexs = {2,0,1,5,3,4,8,6,7};
        AddIndex(indexs);
    }

    private void East()
    {
        int[] indexs = { 1,2,0,4,5,3,7,8,6 };
        AddIndex(indexs);
    }

    private void South()
    {
        int[] indexs = { 3,4,5,6,7,8,0,1,2 };
        AddIndex(indexs);
    }

    private void SouthWest()
    {
        int[] indexs = { 5,3,4,8,6,7,2,0,1 };
        AddIndex(indexs);
    }

    private void SouthEast()
    {
        int[] indexs = { 4,5,3,7,8,6,1,2,0};
        AddIndex(indexs);
    }

    private void NorthEast()
    {
        int[] indexs = { 7, 8, 6, 1, 2, 0, 4, 5, 3 }    ;
        AddIndex(indexs);
    }

    private void NorthWest()
    {
        int[] indexs = { 8,6,7,5,0,1,2,3,4 };
        AddIndex(indexs);
    }
    private void AddIndex(int[] indexs)
    {
        for (int i = 0; i < 9; i++)
        {
            maps.Add(mapInfor[indexs[i]]);
        }
    }
    private void SetDir()
    {
        maps[0].OnNorthWest(Center.transform.position);
        maps[1].OnNorth(Center.transform.position);
        maps[2].OnNorthEast(Center.transform.position);
        maps[3].OnWest(Center.transform.position);
        maps[4].SetDir(PosDir.Center);
        maps[5].OnEast(Center.transform.position);
        maps[6].OnSouthWest(Center.transform.position);
        maps[7].OnSouth(Center.transform.position);
        maps[8].OnSouthEast(Center.transform.position);
    }
}
