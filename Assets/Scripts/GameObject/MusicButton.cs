
using Command;
using Entity;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton:MonoBehaviour
{
    [Inject] private readonly UnlockCommand _unlockCommand;

    public Animator Animator;
    public GameObject turnOn;
    public GameObject turnOff;
    public void Start()
    {
        var button = turnOn.GetComponent<Button>();
        button.onClick.AddListener(TurnOff);
        
        var button2 = turnOff.GetComponent<Button>();
        button2.onClick.AddListener(TurnOn);
    }

    private void TurnOff()
    {
         
        _unlockCommand.Unlock(LockType.MusicPlaying, Time.time);
        Animator.enabled = false;
        turnOff.SetActive(true);
        turnOn.SetActive(false);
    }
    private void TurnOn()
    {
         
      
        Animator.enabled = true;
        turnOff.SetActive(false);
        turnOn.SetActive(true);
    }
}
