using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Command;
using Entity;
using JetBrains.Annotations;
using Reflex.Attributes;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public ResultItem resultPrefab;
    public GameObject resultPanel;
    
    [Inject] private GameCommand _gameCommand;
    
    private Dictionary<PuzzleType, double> _scores;
    // Start is called before the first frame update
    void Start()
    {
        _scores = _gameCommand.GetScores();
        double maxScore = GetMaxScore();
        StartCoroutine(BuildResultItems(_scores, maxScore, 1.0f));
    }
    
    public double GetMaxScore()
    {
        double maxScore = 0;
        foreach (var score in _scores)
        {
            if (score.Value > maxScore)
            {
                maxScore = score.Value;
            }
        }

        return maxScore;
    }
    
    public IEnumerator BuildResultItems(Dictionary<PuzzleType, double> scores, double maxScore, float waitTime)
    {
        foreach (var score in scores)
        {
            ResultItem resultItem = Instantiate(resultPrefab, resultPanel.transform);
            resultItem.SetResultItem(score.Key, score.Value, maxScore);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
