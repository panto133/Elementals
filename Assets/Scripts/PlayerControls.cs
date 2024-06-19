using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private ResourceManager resources;

    private void Start()
    {
        resources = GetComponent<ResourceManager>();
    }
    public void MineResource(string name)
    {
        resources.UpdateResource(name, 15);
    }
}
