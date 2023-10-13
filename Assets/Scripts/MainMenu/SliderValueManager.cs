using UnityEngine;

public class SliderValueManager : MonoBehaviour
{
    public float spawnRateValue = 0.2f;  
    public float cellSizeValue = 0.2f;

    public static SliderValueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
