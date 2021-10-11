using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionController : MonoBehaviour
{

    public GameObject questionPrompt;

    private List<GameObject> questionButtons;
    private List<GameObject> answerButtons;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("QuestionController Start");

        questionButtons = new List<GameObject>();
        answerButtons = new List<GameObject>();
        // populate arrays
        questionButtons.Add(gameObject.transform.GetChild(0).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(1).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(2).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(3).gameObject);

        answerButtons.Add(gameObject.transform.GetChild(4).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(5).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(6).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(7).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Hides the buttons, both question buttons and answer buttons depending
    /// on input
    /// </summary>
    /// <param name="hideQuestions">
    /// boolean parameter. True if you want to hide the question buttons.
    /// false if you want to hide the answer buttons</param>
    void hideButtons(bool hideQuestions)
    {
        if (hideQuestions)
        {
            questionButtons[0].SetActive(false);
            questionButtons[1].SetActive(false);
            questionButtons[2].SetActive(false);
            questionButtons[3].SetActive(false);
        }
        else
        {
            answerButtons[0].SetActive(false);
            answerButtons[1].SetActive(false);
            answerButtons[2].SetActive(false);
            answerButtons[3].SetActive(false);
        }
    }

    void showButtons(bool showQuestions)
    {
        if (showQuestions)
        {
            questionButtons[0].SetActive(true);
            questionButtons[1].SetActive(true);
            questionButtons[2].SetActive(true);
            questionButtons[3].SetActive(true);
        }
        else
        {
            answerButtons[0].SetActive(true);
            answerButtons[1].SetActive(true);
            answerButtons[2].SetActive(true);
            answerButtons[3].SetActive(true);
        }
    }

    public void clickQuestion(int childIndex)
    {
        Debug.Log("QuestionController clickQuestion");

        // Hide all questions     
        hideButtons(true);

        // Generate question prompt
        // Grab text out of question button (might change based on question service)
        // childIndex is passed by the button calling this function. It tells us which button is calling us
        var questionText = questionButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().text;
        Debug.Log(questionText);

        // put text into question prompt
        questionPrompt.GetComponent<TMP_Text>().text = questionText;

        // Show question prompt and possible answers
        questionPrompt.SetActive(true);
        showButtons(false);
    }

    public void clickAnswer(int childIndex)
    {
        Debug.Log("QuestionController clickAnswer");

        // Hide all answers
        hideButtons(false);

        // TODO logic for correct answer or incorrect answer selection

        // reset question prompt
        questionPrompt.GetComponent<TMP_Text>().text = "Question Prompt";

        // Hide question prompt, show questions
        questionPrompt.SetActive(false);
        showButtons(true);

    }
}
