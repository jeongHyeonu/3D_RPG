using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField ageField;

    private void Start()
    {
        nameField.text = PlayerPrefs.GetString("Name");
        ageField.text = PlayerPrefs.GetInt("Age").ToString();
    }

    public void SaveData()
    {
        if(nameField.text!="" && ageField.text != "")
        {
            PlayerPrefs.SetString("Name", nameField.text);
            PlayerPrefs.SetInt("Age", int.Parse(ageField.text));
            PlayerPrefs.Save();
        }
    }
}
