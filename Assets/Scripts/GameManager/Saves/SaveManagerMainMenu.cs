using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerMainMenu : SaveManager
{
    [SerializeField] private LevelSelect _levelSelect;

    protected override void UpdateLevels()
    {
        _levelSelect.UpdateLevels(SaveDataWrapper.levelDataList);
    }
}
