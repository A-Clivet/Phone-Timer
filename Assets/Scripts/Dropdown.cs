using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Dropdown : MonoBehaviour
{
    [Range(0,60)]
    [SerializeField] private int drops; // nobre de case dans le dropdown
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private bool hour = false;
    private string _lastText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InitializedList();
        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }
    void InitializedList()
    {
        if (hour)
        {
            _lastText = "Hours";
        }
        if (!hour)
        {
            _lastText = "Minutes";
        }
        
        for (int i = 0; i < drops; i++)
        {
            TMP_Dropdown.OptionData time = new();
            time.text = i.ToString() + " " + _lastText;
            dropdown.options.Add(time);
        }
    }
    
    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        // Récupère l'index de l'option sélectionnée
        int index = dropdown.value;

        // Récupère le texte de l'option sélectionnée
        string number = dropdown.options[index].text.Split(" ")[0];
        
        // Affiche le texte dans l'UI (ou utilisez-le comme vous le souhaitez)
        Chrono.Instance.ChangeChrono(number, hour);
    }
}
