using UnityEngine;
using TMPro;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private Canvas _questionsCanvas;
    [SerializeField] private Canvas _completedquizCanvas;
    [SerializeField] private TextMeshProUGUI _completionMessageText;

    public void HandleQuizCompleted(bool hasWon, int finalScore, float timeTaken)
    {
        _questionsCanvas.gameObject.SetActive(false);
        _completionMessageText.gameObject.SetActive(true);

        if (hasWon)
        {
            _completionMessageText.text = "Congratulations! You won!\nScore: " + finalScore + "\nTime Taken: " + Mathf.RoundToInt(timeTaken) + " seconds";
        }
        else
        {
            _completionMessageText.text = "Good luck next time!\nScore: " + finalScore + "\nTime Taken: " + Mathf.RoundToInt(timeTaken) + " seconds";
        }
    }
}