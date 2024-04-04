using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private EnemyKillCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _scoreCounter.EnemiesKilledChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.EnemiesKilledChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
       _score.text = score.ToString();
    }
}
