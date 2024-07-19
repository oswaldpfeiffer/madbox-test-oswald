using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private IPersistentDataManager _persistentDataManager;
    [SerializeField] private TMP_Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _persistentDataManager = ServiceLocator.Instance.GetService<IPersistentDataManager>();
        EventBus.OnEnemyKilled += EnemyKilled;
        UpdateScoreText();
    }

    void OnDisable()
    {
        EventBus.OnEnemyKilled -= EnemyKilled;
    }

    private void EnemyKilled(int score)
    {
        int totalCount = _persistentDataManager.GetInt(PlayerPrefKeys.KEY_KILLCOUNT, 0);
        _persistentDataManager.SaveInt(PlayerPrefKeys.KEY_KILLCOUNT, totalCount + score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        int totalCount = _persistentDataManager.GetInt(PlayerPrefKeys.KEY_KILLCOUNT, 0);
        _scoreText.text = totalCount.ToString();
    }
}
