using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ranks;
    [SerializeField] private TMP_Text _userName;
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _points;

    public void Render(int rank,string userName,int points)
    {
        foreach (var obj in _ranks)
        {
            obj.SetActive(false);
        }

        switch (rank)
        {
            case 1:
                _ranks[0].gameObject.SetActive(true);
                break;
            case 2:
                _ranks[1].gameObject.SetActive(true);
                break;
            case 3:
                _ranks[2].gameObject.SetActive(true);
                break;
            case 4:
                _ranks[3].gameObject.SetActive(true);
                break;
        }

        _rank.text = rank.ToString();
        _userName.text = userName;
        _points.text = points.ToString();
    }
}
