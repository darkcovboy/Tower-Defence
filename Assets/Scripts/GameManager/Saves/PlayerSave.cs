using System.Collections.Generic;

public class PlayerSave
{
    private int _maxLevel;
    private readonly int firstLevelId = 1;
    private readonly int _scoreStart;

    public PlayerSave(int maxLevel)
    {
        _maxLevel = maxLevel;
    }

    public SaveDataWrapper LoadNewData()
    {
        SaveDataWrapper saveDataWrapper = new()
        {
            LevelDataList = InitLevelData(),
            Score = _scoreStart
        };
        return saveDataWrapper;
    }

    private List<LevelData> InitLevelData()
    {
        List<LevelData> levelDataList = new();

        for (int i = 1; i <= _maxLevel; i++)
        {
            LevelData levelData = new()
            {
                LevelId = i,
                Stars = 0
            };

            if (levelData.LevelId == firstLevelId)
            {
                levelData.IsUnblock = true;
            }
            else
            {
                levelData.IsUnblock = false;
            }

            levelDataList.Add(levelData);
        }

        return levelDataList;
    }

}

[System.Serializable]
public class LevelData
{
    public int LevelId;
    public bool IsUnblock = false;
    public int Stars;
}