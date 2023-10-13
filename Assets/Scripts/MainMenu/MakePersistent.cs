using UnityEngine;

public class MakePersistent : MonoBehaviour
{
    private void Awake()
    {
        // Make this GameObject persistent across scene changes
        DontDestroyOnLoad(gameObject);
    }
}
