using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    [SerializeField]
    private BuildingScriptable buildingData;

    [SerializeField]
    private Button button;

    void Start()
    {
        Transform panelTransform = this.transform;

        foreach (var towerData in buildingData.data)
        {
            Button newButton = Instantiate(button, panelTransform);
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = towerData.name;
            }

        }

    }
}
