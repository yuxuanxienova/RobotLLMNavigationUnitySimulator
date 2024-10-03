using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public TMP_InputField inputField_x; // Reference to the TMP_InputField
    public float inputNumber_x; // Variable to store the converted float value

    public TMP_InputField inputField_y; // Reference to the TMP_InputField
    public float inputNumber_y; // Variable to store the converted float value

    public TMP_InputField inputField_z; // Reference to the TMP_InputField
    public float inputNumber_z; // Variable to store the converted float value

    public PlayerControllerCoordinate playerControllerCoordinate;
    void Start()
    {
        // Ensure inputField is assigned and set up a listener for input changes
        if (inputField_x != null && inputField_y != null && inputField_z != null)
        {
            inputField_x.onValueChanged.AddListener(OnInputChanged_x);
            inputField_y.onValueChanged.AddListener(OnInputChanged_y);
            inputField_z.onValueChanged.AddListener(OnInputChanged_z);
        }
        else
        {
            Debug.LogError("InputField reference is not set in the UIController script.");
        }
    }

    // This method is called whenever the input field value changes
    void OnInputChanged_x(string input)
    {
        // Try to parse the input to a float
        if (float.TryParse(input, out float result))
        {
            inputNumber_x = result;
            // Debug.Log("Converted input to float: " + inputNumber_x);
        }
        else
        {
            // Debug.LogError("Invalid input. Please enter a valid number.");
        }
    }
    void OnInputChanged_y(string input)
    {
        // Try to parse the input to a float
        if (float.TryParse(input, out float result))
        {
            inputNumber_y = result;
            // Debug.Log("Converted input to float: " + inputNumber_y);
        }
        else
        {
            // Debug.LogError("Invalid input. Please enter a valid number.");
        }
    }

    void OnInputChanged_z(string input)
    {
        // Try to parse the input to a float
        if (float.TryParse(input, out float result))
        {
            inputNumber_z = result;
            // Debug.Log("Converted input to float: " + inputNumber_z);
        }
        else
        {
            // Debug.LogError("Invalid input. Please enter a valid number.");
        }
    }


    public void OnClickButtonUPdateTargetPosition()
    {
        playerControllerCoordinate.SetTargetPosition(inputNumber_x,inputNumber_y,inputNumber_z);

    }
}
