using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool alive = false;
    public Material aliveMaterial;
    public Material deadMaterial;

    private Renderer cellRenderer;

    public int timeAlive;
    public int greenColor;
    public int WhiteColor;
    public int purpleColor;

    private void Start()
    {
        cellRenderer = GetComponent<Renderer>();
        UpdateStatus();
        timeAlive = 0;
    }

    public void UpdateStatus()
    {
        if (alive)
        {
            cellRenderer.material = aliveMaterial;
        }
        else
        {
            cellRenderer.material = deadMaterial;
            timeAlive = 0;
        }
    }

    private void Update()
    {
        if (alive)
        {           
            UpdateColorBasedOnGeneration();
            timeAlive++;
        }
    }

    private void UpdateColorBasedOnGeneration()
    {
        Color color;

        if (timeAlive == 0)
        {
            color = Color.green;
            greenColor++;
        }
        else if (timeAlive >= 1 && timeAlive !<5) 
        {
            color = Color.white;
            greenColor--;
            WhiteColor++;            
        }
        else
        {
            color = Color.magenta;
            WhiteColor--;
            purpleColor++;
        }

        cellRenderer.material.color = color;
    }
}
