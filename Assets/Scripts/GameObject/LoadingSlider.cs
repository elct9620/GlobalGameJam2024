using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [Inject] private readonly UnlockCommand _unlockCommand;
    
    public Slider slider;
    public TMP_Text progressText;
    
    void Start()
    {
        slider.onValueChanged.AddListener(delegate { OnSliderChanged(); });
    }
    
    private void OnSliderChanged()
    {
        if(slider.value >= 1)
        {
            Debug.Log("Loading Progress Unlocked");
            _unlockCommand.Unlock(LockType.LoadingProgress, Time.time);
        }
        
        int progress = (int) (slider.value * 100);
        progressText.text = $"{progress}%";
    }
}
