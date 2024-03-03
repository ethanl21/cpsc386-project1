using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Allows the power up's type to be specified in the editor
    // Only a "Camera" power up is implemented, but this could be expanded
    [SerializeField] public string powerUpType = "Camera";
}
