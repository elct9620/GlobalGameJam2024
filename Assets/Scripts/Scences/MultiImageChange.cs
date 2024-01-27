using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class MultiImageChange:MonoBehaviour
    {
        public List<Button> Buttons;
        public Image Image;
        public List<Sprite> Sprites;
        
        public void Start()
        {

            if (Buttons.Count != Sprites.Count)
            {
                throw new Exception("圖片數量不對");
            }

            for (var index = 0; index < Buttons.Count; index++)
            {
                var test = index;
                var button = Buttons[index];
                button.onClick.AddListener(()=> ChangeImage(test,button));
            }
        }
        
        void ChangeImage(int index,Button button)
        {
            //Output this to console when the Button3 is clicked
            Image.sprite = Sprites[index];
            button.interactable = false;

        }
    }
}