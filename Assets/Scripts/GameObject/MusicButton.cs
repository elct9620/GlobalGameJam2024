
using Command;
using Entity;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton:MonoBehaviour
{
    [Inject] private readonly UnlockCommand _unlockCommand;

    public GameObject turnOn;
    public GameObject turnOff;
    public void Start()
    {
        var button = GetComponent<Button>();
        
        button.onClick.AddListener(Unlock);
        
    }

    private void Unlock()
    {
        var result = _unlockCommand.Unlock(LockType.MusicPlaying,Time.time);

        if (result)
        {
            turnOff.SetActive(true);
            turnOn.SetActive(false);
        }

    }
}
