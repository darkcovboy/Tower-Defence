using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerContainer : MonoBehaviour, ICoroutineRunner
{
    public static SaveManager PlayerSave { get; private set; }

    private void Awake()
    {
        if(PlayerSave != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Create()
    {
        PlayerSave = new SaveManager(this);
    }
}
