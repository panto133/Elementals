using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private GameObject selectedUnit;
    [SerializeField]
    private Material selectedMat;
    [SerializeField]
    private Material defaultMat;
    [SerializeField]
    private PlayerControls player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Unit"))
                {
                    if(selectedUnit != null && hit.collider.CompareTag("Unit"))
                    {
                        selectedUnit.GetComponent<ElementalLogic>().DeselectUnit();
                    }
                    selectedUnit = hit.transform.gameObject;
                    selectedUnit.GetComponent<ElementalLogic>().SelectUnit();
                }
                else
                {
                    if(selectedUnit != null)
                        selectedUnit.GetComponent<ElementalLogic>().DeselectUnit();
                    selectedUnit = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (selectedUnit == null)
                    return;
                if(hit.collider.CompareTag("Cell"))
                    selectedUnit.transform.position = hit.transform.position + new Vector3(0, 1, 0);
                if(hit.collider.CompareTag("Resource"))
                {
                    selectedUnit.transform.position = hit.transform.position + new Vector3(0, 1, 0);
                    if (hit.collider.name.Contains("Earth"))
                        player.MineResource("earth");
                    if (hit.collider.name.Contains("Fire"))
                        player.MineResource("fire");
                    if (hit.collider.name.Contains("Water"))
                        player.MineResource("water");
                    if (hit.collider.name.Contains("Air"))
                        player.MineResource("air");
                    if (hit.collider.name.Contains("Gold"))
                        player.MineResource("gold");
                }
            }
        }
    }
}
