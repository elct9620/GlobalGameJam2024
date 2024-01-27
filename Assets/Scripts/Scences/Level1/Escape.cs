using System;
using Command;
using Reflex.Attributes;
using Repository;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Level1
{
    public class Escape : MonoBehaviour
    {
        [Inject] private readonly Level _level;

        public void OnMouseDown()
        {
            _level.End(Time.time);
            SceneManager.LoadScene("Enterance");
        }
    }
}