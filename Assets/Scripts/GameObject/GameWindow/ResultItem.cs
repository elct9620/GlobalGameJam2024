using System.Collections;
using System.Collections.Generic;
using Entity;
using TMPro;
using UnityEngine;

public class ResultItem : MonoBehaviour
{
    public TMP_Text puzzleName;
    public TMP_Text score;
    
    public void SetResultItem(PuzzleType puzzleType, double score)
    {
        puzzleName.text = puzzleType.ToString();
        this.score.text = FormatScore(score);
    }

    private static string FormatScore(double score)
    {
        int hour = (int) score / 3600;
        int minute = (int) (score % 3600) / 60;
        int second = (int) (score % 3600) % 60;
        
        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }
}
