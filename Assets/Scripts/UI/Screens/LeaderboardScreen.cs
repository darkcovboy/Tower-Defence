using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Linq;

public class LeaderboardScreen : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private RankView _template;
    [SerializeField] private RankView _user;
    [SerializeField] private GameObject _panel;

    private SaveManager _saveManager;
    private readonly string _leaderBoardName = "TowerDefenceUserLeaderboard";
    private readonly string _anonymous = "Anonymous";

    private void OnEnable()
    {
        ClearChildren(_container.transform);
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }

        if (PlayerAccount.IsAuthorized == true)
        {
            if(_saveManager.Score > 0)
                Leaderboard.SetScore(_leaderBoardName, _saveManager.Score);

            ShowCurrentUser();
            ShowAllUsers();
        }
        else
        {
            if(_panel != null)
            {
                _panel.Deactivate();
            }
            
            gameObject.Deactivate();
        }
    }

    public void Init(SaveManager saveManager)
    {
        _saveManager = saveManager;
    }

    private void ShowAllUsers()
    {
        Leaderboard.GetEntries(_leaderBoardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                if (entry.score > 0)
                {
                    var view = Instantiate(_template, _container.transform);
                    string name = entry.player.publicName;

                    if (string.IsNullOrEmpty(name))
                        name = _anonymous;

                    view.Render(entry.rank, name, entry.score);
                }
            }
        });
    }

    private void ShowCurrentUser()
    {
        Leaderboard.GetPlayerEntry(_leaderBoardName, (result) =>
        {
            if (result != null)
            {
                string name = result.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = _anonymous;

                _user.Render(result.rank, name, result.score);
            }
        });
    }

    private void ShowUsersDemo()
    {
        List<User> users = new List<User>()
        {
            new User(1, "dillon", 800),
            new User(2, "dima", 700),
            new User(3, "zhasmin", 600),
            new User(4, "pisya", 500),
        };

        foreach (var user in users)
        {
            var view = Instantiate(_template, _container.transform);

            view.Render(user.Rank, user.Name, user.Score);
        }
    }

    private void ClearChildren(Transform transform)
    {
        var children = transform.Cast<Transform>().ToArray();

        foreach (var child in children)
        {
            Object.DestroyImmediate(child.gameObject);
        }
    }
}

[System.Serializable]
public class User
{
    public int Rank;
    public string Name;
    public int Score;

    public User(int rank, string name, int score)
    {
        Rank = rank;
        Name = name;
        Score = score;
    }
}
