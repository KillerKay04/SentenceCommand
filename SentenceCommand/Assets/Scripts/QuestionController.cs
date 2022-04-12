using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using UnityEngine.Networking;

public class QuestionController : MonoBehaviour
{
    const float DELAY = 2.0f;

    // unity object refs
    public GameObject questionPrompt;
    public GameObject fireButton;
    public GameObject answerGroup;
    public GameObject ammoTypes;
    private List<GameObject> questionButtons;
    private List<GameObject> answerButtons;
    private List<Question> questionMapping;

    List<Question> qList;
    int nextQ;
    int activeQuestion;

    // Audio
    private AudioGameScene ags;

    /// <summary>
    /// Start is called before the first frame update. Initializes the question manager.
    /// </summary>
    public void Start()
    {
        // unity object arrays
        questionButtons = new List<GameObject>();
        answerButtons = new List<GameObject>();

        questionButtons.Add(gameObject.transform.GetChild(0).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(1).gameObject);
        questionButtons.Add(gameObject.transform.GetChild(2).gameObject);      
        questionButtons.Add(gameObject.transform.GetChild(3).gameObject);


        answerButtons.Add(gameObject.transform.GetChild(4).GetChild(0).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(4).GetChild(1).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(4).GetChild(2).gameObject);
        answerButtons.Add(gameObject.transform.GetChild(4).GetChild(3).gameObject);

        qList = new List<Question>();
        questionMapping = new List<Question>();
        activeQuestion = -1;

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

        // Audio
        ags = GameObject.FindObjectOfType(typeof(AudioGameScene)) as AudioGameScene;

        // QuestionsCounter
        GlobalVars.questionsRight = 0;
        GlobalVars.questionsWrong = 0;
    }  

    /// <summary>
    /// Updates the text of the question button to match the underlying question object.
    /// Also updates the color of the ammotype label to match the underlying question object.
    /// </summary>
    /// <param name="qIndex">The index of the question you wish to update</param>
    private void updateQuestion(int qIndex)
    {
        // get prompt out of Question and stick into button text
        questionButtons[qIndex].transform.GetChild(0).GetComponent<TMP_Text>().text = questionMapping[qIndex].prompt;
        // set ammotype label
        switch (questionMapping[qIndex].ammoType)
        {
            case GlobalVars.AmmoType.Standard:
                // set ammoType color to red
                questionButtons[qIndex].transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;
            case GlobalVars.AmmoType.Homing:
                // set ammoType color to blue
                questionButtons[qIndex].transform.GetChild(1).GetComponent<Image>().color = new Color32(0, 145, 46, 255);
                break;
            case GlobalVars.AmmoType.Split:
                // set ammoType color to yellow
                questionButtons[qIndex].transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 174, 0, 255);
                break;
        }
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

        // Assign a random ammo type to the question
        // setting it here makes it so the ammoType is not tied to the question.
        // That way, when we see this question again, it won't necessarily be the same ammoType.
        System.Random random = new System.Random();
        // right now it will be an even 33% chance for each ammo type
        int x = random.Next(3);
        switch(x)
        {
            case 0:
                nextUp.ammoType = GlobalVars.AmmoType.Standard;
                break;
            case 1:
                nextUp.ammoType = GlobalVars.AmmoType.Homing;
                break;
            case 2:
                nextUp.ammoType = GlobalVars.AmmoType.Split;
                break;
        }

        return nextUp;
    }

    /// <summary>
    /// Main JSON Parser.
    /// Parses a JSON file into a list of question objects
    /// which the questions will pull from
    /// </summary>
    void questionParser()
    {        
        // parse JSON into separate questions
        JObject o = JObject.Parse(GlobalVars.json);
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
        answerGroup.SetActive(false);
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
        answerGroup.SetActive(true);
    }

    /// <summary>
    /// button handler for when a question button is clicked
    /// </summary>
    /// <param name="childIndex">The index of the question calling this handler. Question 0 through 3</param>
    public void clickQuestion(int childIndex)
    {        
        // populate prompt
        questionPrompt.GetComponent<TMP_Text>().text = questionMapping[childIndex].prompt;

        // populate answers
        List<string> answers = questionMapping[childIndex].getAnswers();
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = answers[i];
        }

        // store clicked question's index
        activeQuestion = childIndex;

        // hide questions
        hideQuestions();

        // show prompt
        questionPrompt.transform.parent.gameObject.SetActive(true);

        // show answers
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

        // using a coroutine in order to have delay for user to read answer
        StartCoroutine(handleAnswer(childIndex));
    }

    IEnumerator handleAnswer(int childIndex)
    {
        // check if correct answer
        string selected = answerButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().text;
        string correct = questionMapping[activeQuestion].correctAns;
        // if correct
        if (selected.Equals(correct))
        {
            // increment questionsRight
            GlobalVars.questionsRight++;

            // make answer green
            answerButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(0.0f, 255.0f, 0.0f, 1.0f);

            // Play correct sound
            ags.PlayAnswerCorrect();

            // delay for user
            yield return new WaitForSeconds(DELAY);

            // reset answer color
            answerButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(233.0f, 255.0f, 218.0f, 1.0f);

            // increment corresponding ammo counter
            switch (questionMapping[activeQuestion].ammoType)
            {
                case GlobalVars.AmmoType.Standard:
                    GlobalVars.ammoStandard++;
                    break;
                case GlobalVars.AmmoType.Homing:
                    GlobalVars.ammoHoming++;
                    break;
                case GlobalVars.AmmoType.Split:
                    GlobalVars.ammoSplit++;                    
                    break;
            }
            // update ammo count labels
            ammoTypes.gameObject.GetComponent<WeaponSelector>().updateValues();
        }
        // incorrect
        else
        {
            // Increment questionsWrong
            GlobalVars.questionsWrong++;
            
            // make answer red
            answerButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(255.0f, 0.0f, 0.0f, 1.0f);

            int correctInd = 0;

            // make correct answer green
            for (int i = 0; i < answerButtons.Count; i++)
            {
                if (answerButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text.Equals(correct))
                {
                    // correct answer, make green
                    correctInd = i;
                    answerButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(0.0f, 255.0f, 0.0f, 1.0f);
                    break;
                }
            }

            // Play sound
            ags.PlayAnswerWrong();

            // delay for user
            yield return new WaitForSeconds(DELAY);

            // reset answers color
            answerButtons[childIndex].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(233.0f, 255.0f, 218.0f, 1.0f);
            answerButtons[correctInd].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(233.0f, 255.0f, 218.0f, 1.0f);    
        }

        // reset prompt
        questionPrompt.GetComponent<TMP_Text>().text = "";

        // hide prompt
        questionPrompt.transform.parent.gameObject.SetActive(false);

        // reset answers
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        }

        // replace stored question with new question
        questionMapping[activeQuestion] = getNextQ();
        updateQuestion(activeQuestion);        
        activeQuestion = -1;

        // hide answers
        hideAnswers();

        // show questions
        showQuestions();
    }
}
