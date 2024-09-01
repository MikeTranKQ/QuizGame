using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionPresenter : MonoBehaviour
{
    [SerializeField] private GamePresenter _gamePresenter;
    [SerializeField] private List<QuestionData> _questionDataList;
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private TextMeshProUGUI[] _answerOptionTextList;
    [SerializeField] private Button[] _answerOptionButtonList;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private int _currentQuestionIndex = 0;
    private int _score = 0;
    private float _elapsedTime = 0f;
    private bool _quizActive = true;

    private void Start()
    {
        UpdateQuestionView(_questionDataList[_currentQuestionIndex]);

        for (int i = 0; i < 4; i++)
        {
            int index = i;
            _answerOptionButtonList[i].onClick.AddListener(
                () =>
                {
                    if (index == _questionDataList[_currentQuestionIndex].CorrectAnswerOptionIndex)
                    {
                        _score++;
                        _scoreText.text = "Score: " + _score;
                        _currentQuestionIndex++;
                        if (_currentQuestionIndex < _questionDataList.Count)
                        {
                            UpdateQuestionView(_questionDataList[_currentQuestionIndex]);
                        }
                        else
                        {
                            _quizActive = false;
                            _gamePresenter.HandleQuizCompleted(true, _score, _elapsedTime);
                        }
                    }
                    else
                    {
                        _quizActive = false;
                        _gamePresenter.HandleQuizCompleted(false, _score, _elapsedTime);
                    }
                }
            );
        }

        StartCoroutine(StartTimer());
    }

    private void UpdateQuestionView(QuestionData questionData)
    {
        _questionText.text = questionData.Question;
        for (int i = 0; i < 4; i++)
        {
            _answerOptionTextList[i].text = questionData.AnswerOptions[i];
        }
    }

    private IEnumerator StartTimer()
    {
        while (_quizActive)
        {
            _elapsedTime += Time.deltaTime;
            _timerText.text = "Time Elapsed: " + Mathf.RoundToInt(_elapsedTime) + "s";
            yield return null;
        }
    }
}
