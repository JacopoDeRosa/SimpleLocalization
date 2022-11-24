using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class LocalizedVariable
{
    public const string locKey = "language";
}

[System.Serializable]
public class LocalizedVariable<T> : LocalizedVariable, ISerializationCallbackReceiver
{
    [SerializeField] private T[] _localizations;

    public T GetVariable { get => _localizations[PlayerPrefs.GetInt(locKey, 0)]; }

    public LocalizedVariable()
    {
        _localizations = new T[Enum.GetNames(typeof(Languages)).Length];
    }

    public void OnBeforeSerialize()
    {
        int numberOfLanguages = Enum.GetNames(typeof(Languages)).Length;

        if (_localizations.Length != numberOfLanguages)
        {
            T[] oldArray = _localizations;

            _localizations = new T[numberOfLanguages];

            for (int i = 0; i < numberOfLanguages; i++)
            {           
                _localizations[i] = oldArray[i];
            }
        }
    }

    public void OnAfterDeserialize()
    {
        
    }
}
