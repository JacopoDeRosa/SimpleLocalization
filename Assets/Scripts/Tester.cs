using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private float _number;
    
    [SerializeField] private LocalizedVariable<string> _helloMessage;

    [SerializeField] private LocalizedVariable<GameObject> _hi;
}
