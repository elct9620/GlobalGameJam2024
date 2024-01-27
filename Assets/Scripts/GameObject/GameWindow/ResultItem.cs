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
        this.score.text = score.ToString();
    }
}
