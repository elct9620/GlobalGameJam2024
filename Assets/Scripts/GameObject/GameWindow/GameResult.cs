using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
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
        StartCoroutine(BuildResultItems(_scores, 1.0f));
    }
    
    public IEnumerator BuildResultItems(Dictionary<PuzzleType, double> scores, float waitTime)
    {
        yield return new WaitForSeconds((float) waitTime);
        foreach (var score in scores)
        {
            ResultItem resultItem = Instantiate(resultPrefab, resultPanel.transform);
            resultItem.SetResultItem(score.Key, score.Value);
        }

        yield return new WaitForSeconds(waitTime);
    }
}
