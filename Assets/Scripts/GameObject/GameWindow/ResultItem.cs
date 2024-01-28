using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultItem : MonoBehaviour
{
    public TMP_Text puzzleName;
    public TMP_Text score;
    public Slider filled;

    public void SetResultItem(PuzzleType puzzleType, double score, double maxScore)
    {
        puzzleName.text = GetDescriptionAttribute(puzzleType);
        this.score.text = FormatScore(score);
        filled.value = (float)(score / maxScore);
    }

    private static string FormatScore(double score)
    {
        int hour = (int)score / 3600;
        int minute = (int)(score % 3600) / 60;
        int second = (int)(score % 3600) % 60;

        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }

    private static string GetDescriptionAttribute(PuzzleType puzzleType)
    {
        string enumName = puzzleType.ToString();
        FieldInfo fieldInfo = puzzleType.GetType().GetField(enumName);
        if (fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        return enumName;
    }
}