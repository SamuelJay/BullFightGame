using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    public GameObject CreateCanvas(string canvasName)
    {
        GameObject canvasPrefab;
        GameObject canvasObject;
        string canvasPath = "Canvases/" + canvasName;
        canvasPrefab = Resources.Load(canvasPath) as GameObject;
        canvasObject = Instantiate(canvasPrefab);
        return canvasObject;
    } 

}
