using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component from the GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Check if the Renderer component exists
        if (renderer != null)
        {
            // Change the color of the material
            renderer.material.color = newColor;
        }
        else
        {
            Debug.LogWarning("No Renderer component found on this GameObject.");
        }
    }
}
