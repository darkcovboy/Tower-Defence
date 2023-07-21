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

    private string _leaderBoardName = "TowerDefenceUserLeaderboard";
    private string _anonymous = "Anonymous";

    private void OnEnable()
    {
        ClearChildren(_container.transform);

        /*
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }

        if (PlayerAccount.IsAuthorized == true)
        {
            Leaderboard.SetScore(_leaderBoardName, (int)_moneyCounter.Money);
            ShowAllUsers();
        }
        else
            gameObject.SetActive(false);
        */

        List<User> users = new List<User>
        {
            new User(1, "Darkcovboy" ,1000),
            new User(2, "פûגפûג" ,900),
            new User(3, "ASdasfas" ,800),
            new User(4, "dfsdfsdf" ,700),
            new User(5, "asdasdasda" ,600)
        };
        ShowAllUsers(users);
        ShowCurrentUser(new User(1, "Darkcovboy", 1000));
    }

    /*
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
    */

    private void ShowAllUsers(List<User> users)
    {
        foreach (var user in users)
        {
            var view = Instantiate(_template, _container.transform);
            view.Render(user.Rank, user.Name, user.Score);
        }
    }

    private void ShowCurrentUser(User user)
    {
        _user.Render(user.Rank, user.Name, user.Score);
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
