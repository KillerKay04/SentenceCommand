using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class QuestionController : MonoBehaviour
{
    // unity object refs
    public GameObject questionPrompt;
    private List<GameObject> questionButtons;
    private List<GameObject> answerButtons;
    private List<Question> questionMapping;

    List<Question> qList;
    int nextQ;

    /// <summary>
    /// Start is called before the first frame update. Initializes the question manager.
    /// </summary>
    void Start()
    {
        // unity object arrays
        questionButtons = new List<GameObject>();
        answerButtons = new List<GameObject>();

        questionButtons.Add(gameObject.transform.GetChild(0).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(1).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(2).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(3).gameObject);

        answerButtons.Add(gameObject.transform.GetChild(4).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(5).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(6).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(7).gameObject);

        qList = new List<Question>();
        questionMapping = new List<Question>();

        // run parser
        questionParser();

        // populate initial questions
        questionMapping.Add(getNextQ());
        updateQuestion(0);
        questionMapping.Add(getNextQ());
        updateQuestion(1);
        questionMapping.Add(getNextQ());
        updateQuestion(2);
        questionMapping.Add(getNextQ());
        updateQuestion(3);

    }

    /// <summary>
    /// sets the text of the questionButton to be the prompt of its underlying question object
    /// </summary>
    /// <param name="qIndex">The index of the question you wish to update</param>
    private void updateQuestion(int qIndex)
    {
        // get prompt out of Question and stick into button text
        questionButtons[qIndex].transform.GetChild(0).GetComponent<TMP_Text>().text = questionMapping[qIndex].prompt;
    }

    // serves up the next question in line
    // will wrap back around to beginning if at end of qList
    private Question getNextQ()
    {
        if (nextQ >= qList.Count)
        {
            nextQ = 0;
        }

        Question nextUp = qList[nextQ];
        nextQ++;
        return nextUp;
    }

    /// <summary>
    /// Main JSON Parser.
    /// Parses a JSON file into a list of question objects
    /// which the questions will pull from
    /// </summary>
    void questionParser()
    {
        // open JSON file *** WILL CHANGE TO WORK WITH Q&A SERVICE ***
        string url = "Assets/Questions/questions.json";

        // parse JSON into separate questions
        using (StreamReader reader = File.OpenText(url))
        {
            JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            long counter = 0;
            foreach (var x in o["records"])
            {
                Question q = new Question(counter);
                // get prompt
                q.prompt = x["question"].ToString();
                // get answers
                List<string> answers = new List<string>();
                foreach (var answer in x["answers"])
                {
                    answers.Add(answer.ToString());
                }
                // set correct answer
                q.correctAns = answers[0];
                q.answers = answers;
                // get explain
                q.explain = x["explain"].ToString();
                // add to qList
                qList.Add(q);
                // increment counter
                counter++;
            }
        }

        // shuffle list
        shuffleQList();

        // Set nextQ to beginning of qList (index 0)
        nextQ = 0;
    }

    /// <summary>
    /// shuffles the Qlist, the list of all our questions.
    /// implements Fisher-Yates O(n) shuffling algorithm.
    /// </summary>
    private void shuffleQList()
    {
        System.Random rand = new System.Random();
        // for i from n-1 downto 1 do
        // j = random int where 0 <= j < n
        // exchange a[i] and j[i]
        for (int i = qList.Count - 1; i > 0; i--)
        {
            int j = rand.Next(qList.Count);
            Question temp = qList[i];
            qList[i] = qList[j];
            qList[j] = temp;
        }
    }

    /// <summary>
    /// Hides the question buttons
    /// </summary>
    void hideQuestions()
    {
        questionButtons[0].SetActive(false);
        questionButtons[1].SetActive(false);
        questionButtons[2].SetActive(false);
        questionButtons[3].SetActive(false);
    }
    /// <summary>
    /// Hides the answer buttons
    /// </summary>
    void hideAnswers()
    {
        answerButtons[0].SetActive(false);
        answerButtons[1].SetActive(false);
        answerButtons[2].SetActive(false);
        answerButtons[3].SetActive(false);
    }
    /// <summary>
    /// Shows the question buttons
    /// </summary>
    void showQuestions()
    {
        questionButtons[0].SetActive(true);
        questionButtons[1].SetActive(true);
        questionButtons[2].SetActive(true);
        questionButtons[3].SetActive(true);
    }
    /// <summary>
    /// Shows the answer buttons
    /// </summary>
    void showAnswers()
    {
        answerButtons[0].SetActive(true);
        answerButtons[1].SetActive(true);
        answerButtons[2].SetActive(true);
        answerButtons[3].SetActive(true);
    }

    /// <summary>
    /// button handler for when a question button is clicked
    /// </summary>
    /// <param name="childIndex">The index of the question calling this handler. Question 0 through 3</param>
    public void clickQuestion(int childIndex)
    {
        // Pseudocode
        /*
         * populate prompt
         * populate answers
         * store clicked question's index
         * hide questions
         * show answers
         */


        // Debug.Log("QuestionController clickQuestion");
        // Hide all questions     
        hideQuestions();

        // Generate question prompt
        // Grab text out of question button (might change based on question service)
        // childIndex is passed by the button calling this function. It tells us which button is calling us
        var questionText = questionButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().text;
        Debug.Log(questionText);

        // put text into question prompt
        questionPrompt.GetComponent<TMP_Text>().text = questionText;

        // Show question prompt and possible answers
        questionPrompt.SetActive(true);
        showAnswers();
    }

    /// <summary>
    /// button handler for when a answer button is clicked
    /// </summary>
    /// <param name="childIndex">The index of the question calling this handler. Answer 0 through 3</param>
    public void clickAnswer(int childIndex)
    {
        // Pseudocode
        /*
         * check if correct answer
         * if correct
         *  make answer green
         *  wait 1 time
         *  increment ammo counter
         * if not correct
         *  make answer red
         *  make correct green
         *  wait 1 time
         * reset prompt
         * reset answers
         * replace stored question with new question
         * hide answers
         * show questions
         */

        // Debug.Log("QuestionController clickAnswer");

        // Hide all answers
        hideAnswers();

        // TODO logic for correct answer or incorrect answer selection

        // reset question prompt
        questionPrompt.GetComponent<TMP_Text>().text = "Question Prompt";

        // Hide question prompt, show questions
        questionPrompt.SetActive(false);
        showQuestions();

    }
}
