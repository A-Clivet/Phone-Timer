using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    [SerializeField] private int _drops;
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private bool _hour = false;
    private string lastText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InitializedList();
        _dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(_dropdown); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializedList()
    {
        if (_hour)
        {
            lastText = "Hours";
        }
        if (!_hour)
        {
            lastText = "Minutes";
        }
        
        for (int i = 0; i < _drops; i++)
        {
            TMP_Dropdown.OptionData time = new();
            time.text = i.ToString() + " " + lastText;
            _dropdown.options.Add(time);
        }
    }
    
    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        // Récupère l'index de l'option sélectionnée
        int index = dropdown.value;

        // Récupère le texte de l'option sélectionnée
        string number = dropdown.options[index].text.Split(" ")[0];
        
        // Affiche le texte dans la console (ou utilisez-le comme vous le souhaitez)
        Chrono.Instance.ChangeChrono(number, _hour);
    }
}
