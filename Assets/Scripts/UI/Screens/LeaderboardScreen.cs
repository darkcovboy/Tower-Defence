using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Linq;

public class LeaderboardScreen : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private RankView _template;

    private string _leaderBoardName = "TowerDefenceUserLeaderboard";
    private string _anonymous = "Anonymous";

    private void OnEnable()
    {
        //PlayerAccount.Authorize();
        ClearChildren(_container.transform);

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

    private void ClearChildren(Transform transform)
    {
        var children = transform.Cast<Transform>().ToArray();

        foreach (var child in children)
        {
            Object.DestroyImmediate(child.gameObject);
        }
    }
}
