using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalLogic : MonoBehaviour
{
    [SerializeField]
    private Material[] elementalMats;
    [SerializeField]
    private Material selectedMat;
    
    private string elementalType;

    private void Start()
    {
        int index = GetComponent<MeshRenderer>().material.ToString().IndexOf(" ");
        string mat = GetComponent<MeshRenderer>().material.ToString().Substring(0, index);
        switch (mat)
        {
            case "Earth":
                elementalType = "earth";
                break;
            case "Fire":
                elementalType = "fire";
                break;
            case "Water":
                elementalType = "water";
                break;
            case "Air":
                elementalType = "air";
                break;
        }
    }
    public void SelectUnit()
    {
        GetComponent<MeshRenderer>().material = selectedMat;
    }
    public void DeselectUnit()
    {
        switch(elementalType)
        {
            case "earth":
                GetComponent<MeshRenderer>().material = elementalMats[0];
                break;
            case "fire":
                GetComponent<MeshRenderer>().material = elementalMats[1];
                break;
            case "water":
                GetComponent<MeshRenderer>().material = elementalMats[2];
                break;
            case "air":
                GetComponent<MeshRenderer>().material = elementalMats[3];
                break;
        }
    }
}
