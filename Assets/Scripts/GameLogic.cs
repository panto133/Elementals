using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private Toggle[] toggleButtons;
    [SerializeField]
    private GameObject choicePanel;

    [SerializeField]
    private HexGrid hexGrid;

    [SerializeField]
    private GameObject[] elementals;

    private int count;

    public void ToggleCheck(int index)
    {
        count = 0;
        for (int i = 0; i < 4; i++)
        {
            if (toggleButtons[i].isOn) count++;
        }

        if (count > 2)
            toggleButtons[index].isOn = false;
    }
    public void StartGame()
    {
        if (count != 2)
            return;
        bool firstElementalsSpawned=false;
        for (int i = 0; i < 4; i++)
        {
            if (toggleButtons[i].isOn)
            {
                GameObject element = Instantiate(elementals[i], transform.position, Quaternion.identity);
                if (!firstElementalsSpawned)
                {
                    element.transform.position = hexGrid.hexGrid[0, 0] + new Vector3(0, 1, 0);
                    firstElementalsSpawned = true;
                }
                else
                    element.transform.position = hexGrid.hexGrid[0, 1] + new Vector3(0, 1, 0);
            }
        }
        choicePanel.SetActive(false);
    }
}
