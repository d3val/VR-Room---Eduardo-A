using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public bool hatsTutorialCompleted { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            return;
        instance = this;
        hatsTutorialCompleted = false;
    }

    public void CompleteHatsTutorial()
    {
        hatsTutorialCompleted = true;
    }

    public void StartHatsTutorial(GameObject HatsTutorial)
    {
        if (hatsTutorialCompleted)
            return;



        HatsTutorial.SetActive(true);
    }
}
