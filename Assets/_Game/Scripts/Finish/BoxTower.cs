using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxTower : Singleton<BoxTower>
{
    public Box[] boxes;
    public Color[] colors;
    public float boxDistance = 0.2f, bigBoxDistance = 0.35f;
    public Transform BoxPos;


    public List<Box> boxesList = new List<Box>();
    

    public float GetTowerBoxY(int towerID = 0)
    {
        return boxes[towerID].transform.position.y;
    }
}
