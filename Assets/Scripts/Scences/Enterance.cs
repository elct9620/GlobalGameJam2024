using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Attributes;

public class Enterance : MonoBehaviour
{
    [Inject] private readonly IEnumerable<string> _strings;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(string.Join(" ", _strings));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
