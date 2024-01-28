using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class MusicPlayerPopupSwitch:MonoBehaviour
    {
        
        public GameObject pop;
        public Button click;
        public Button click2;

        public void Start()
        {
            click.onClick.AddListener(Switch);
            click2.onClick.AddListener(Switch);
        }

        private void Switch()
        {
           pop.SetActive(!pop.activeSelf);
        }
    }
}