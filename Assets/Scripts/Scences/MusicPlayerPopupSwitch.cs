using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class MusicPlayerPopupSwitch:MonoBehaviour
    {
        
        public GameObject pop;
        public Button click;

        public void Start()
        {
            click.onClick.AddListener(Switch);
        }

        private void Switch()
        {
           pop.SetActive(!pop.activeSelf);
        }
    }
}