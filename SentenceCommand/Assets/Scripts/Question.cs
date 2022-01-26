using System;
using System.Collections;
using System.Collections.Generic;

public class Question
{
    public long id { get; }
    public string prompt { get; set; }
    public List<string> answers;
    public string correctAns { get; set; }
    public string explain { get; set; } // For future use
    public string category { get; set; }
    public GlobalVars.AmmoType ammoType { get; set; }

    public Question(long id)
    {
        this.id = id;
    }    

    public List<string> getAnswers()
    {
        shuffleAns();
        return answers;
    }

    public void setAnswers(List<string> answers)
    {
        this.answers = answers;
    }

    // implements an O(n) Fisher-Yates shuffle
    private void shuffleAns()
    {
        Random rand = new Random();
        // for i from n-1 downto 1 do
        // j = random int where 0 <= j < n
        // exchange a[i] and j[i]
        for (int i = answers.Count - 1; i > 0; i--)
        {
            int j = rand.Next(answers.Count);
            string temp = answers[i];
            answers[i] = answers[j];
            answers[j] = temp;
        }        
    }

    public override string ToString()
    {
        String s = prompt;
        foreach (string ans in answers)
        {
            s = s + "\n\t" + ans;
        }
        return s;
    }
}
