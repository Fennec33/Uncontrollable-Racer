using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankingNumber;
    [SerializeField] private TextMeshProUGUI rankingSuffix;

    private int _playerRanking = 0;
    private string _playerRankingSuffix = "";

    public void DisplayCurrentRanking(int ranking)
    {
        if (ranking == _playerRanking) return;

        _playerRanking = ranking;

        _playerRankingSuffix = GetSuffixForNumber(_playerRanking);

        rankingNumber.text = _playerRanking.ToString();
        rankingSuffix.text = _playerRankingSuffix;
    }

    private string GetSuffixForNumber(int number)
    {
        string suffix = "";
        int num = number % 10;

        if (num == 1)
        {
            suffix = "st";
        }
        else if (num == 2)
        {
            suffix = "nd";
        }
        else if (num == 3)
        {
            suffix = "rd";
        }
        else
        {
            suffix = "th";
        }

        return suffix;
    }
}
