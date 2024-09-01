using UnityEngine;


[CreateAssetMenu(fileName = "QuestionData", menuName = "Question Data", order = 0)]
public class QuestionData : ScriptableObject
{
    [field: SerializeField]
    [field: TextArea]
    public string Question { get; private set; }

    [field: SerializeField] public string[] AnswerOptions { get; private set; }
    [field: SerializeField] public int CorrectAnswerOptionIndex { get; private set; }
}