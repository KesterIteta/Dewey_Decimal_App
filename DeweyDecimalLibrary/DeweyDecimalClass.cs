using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalLibrary
{
    public class DeweyDecimalClass
    {
        private List<string> callNumberList;
        private Dictionary<string, string> callNumbers;
        private List<string> descriptionList;
        private List<string> shuffledDescriptionList;
        private List<string> shuffledCallNumbersList;
        private int currentQuestionIndex;
        private int numQuestions;
        private int score;

        public DeweyDecimalClass()
        {
            callNumberList = new List<string>();
            callNumbers = new Dictionary<string, string>();
            descriptionList = new List<string>();
            shuffledDescriptionList = new List<string>();
            shuffledCallNumbersList = new List<string>();
            currentQuestionIndex = 0;
            numQuestions = 10;
            score = 0;

            // Initialize the call number list and dictionary
            callNumberList.Add("000");
            callNumberList.Add("100");
            callNumberList.Add("200");
            callNumberList.Add("300");
            callNumberList.Add("400");
            callNumberList.Add("500");
            callNumberList.Add("600");
            callNumberList.Add("700");
            callNumberList.Add("800");
            callNumberList.Add("900");

            callNumbers.Add("000", "Computer science");
            callNumbers.Add("100", "Philosophy & psychology");
            callNumbers.Add("200", "Religion");
            callNumbers.Add("300", "Social sciences");
            callNumbers.Add("400", "Language");
            callNumbers.Add("500", "Science");
            callNumbers.Add("600", "Technology");
            callNumbers.Add("700", "Arts & recreation");
            callNumbers.Add("800", "Literature");
            callNumbers.Add("900", "History & geography");

            // Initialize the description list
            descriptionList.Add("Computer science");
            descriptionList.Add("Philosophy & psychology");
            descriptionList.Add("Religion");
            descriptionList.Add("Social sciences");
            descriptionList.Add("Language");
            descriptionList.Add("Science");
            descriptionList.Add("Technology");
            descriptionList.Add("Arts & recreation");
            descriptionList.Add("Literature");
            descriptionList.Add("History & geography");
        }

        public void GenerateQuestionSet(bool callNumberFirst)
        {
            Random random = new Random();

            List<string> questionCallNumbers = new List<string>();
            List<string> questionDescriptions = new List<string>();

            // if callNumberFirst==true, it means the questions will be the call numbers
            // so we first have to randomly select 4 call numbers and shuffle descriptions
            if (callNumberFirst) {

                // Generate a random set of four call numbers and their descriptions
                for (int i = 0; i < 4; i++)
                {
                    int callNumberIndex = random.Next(callNumberList.Count);
                    string callNumber = callNumberList[callNumberIndex];
                    string description = callNumbers[callNumber];

                    questionCallNumbers.Add(callNumber);
                    questionDescriptions.Add(description);

                    // Remove the call number from the list to avoid duplicates
                    callNumberList.RemoveAt(callNumberIndex);
                }

                // Add three additional descriptions that are not in the current set
                for (int i = 0; i < 3; i++)
                {
                    string description = descriptionList[random.Next(descriptionList.Count)];

                    if (!questionDescriptions.Contains(description))
                    {
                        questionDescriptions.Add(description);
                    }
                    else
                    {
                        i--;
                    }
                }

                // Shuffle the descriptions
                shuffledDescriptionList = questionDescriptions.OrderBy(x => random.Next()).ToList();

                // save the random call numbers to this variable
                shuffledCallNumbersList = questionCallNumbers;

                // Add the call numbers back to the list
                callNumberList.AddRange(questionCallNumbers);

            }

            else
            // This runs if the questions are now the descriptions and user is matching description to call number
            {
                // Generate a random set of four call numbers and their descriptions
                for (int i = 0; i < 4; i++)
                {
                    int callNumberIndex = random.Next(callNumberList.Count);
                    string callNumber = callNumberList[callNumberIndex];
                    string description = callNumbers[callNumber];

                    questionCallNumbers.Add(callNumber);
                    questionDescriptions.Add(description);

                    // Remove the call number from the list to avoid duplicates
                    callNumberList.RemoveAt(callNumberIndex);
                }

                // Add three additional call numbers that are not in the current set
                for (int i = 0; i < 3; i++)
                {
                    string callNumber = callNumberList[random.Next(callNumberList.Count)];

                    if (!questionCallNumbers.Contains(callNumber))
                    {
                        questionCallNumbers.Add(callNumber);
                    }
                    else
                    {
                        i--;
                    }
                }

                // Shuffle the descriptions
                shuffledDescriptionList = questionDescriptions.OrderBy(x => random.Next()).ToList();

                // Add the call numbers back to the list
                callNumberList.AddRange(questionCallNumbers);

                // Save the random call numbers to this variable
                shuffledCallNumbersList = questionCallNumbers.OrderBy(x => random.Next()).ToList();  
            }

            // Increment current question index
            currentQuestionIndex ++;
        }
        public bool CheckAnswer(string callNumber, string description)
        {
            if (callNumbers[callNumber] == description)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> GetCallNumbers()
        {
            return shuffledCallNumbersList;
        }

        public List<string> GetDescriptions()
        {
            return shuffledDescriptionList;
        }

        public int GetCurrentQuestionIndex()
        {
            return currentQuestionIndex;
        }

        public int GetNumQuestions()
        {
            return numQuestions;
        }

        public int GetScore()
        {
            return score;
        }

        public void IncrementScore()
        {
            score++;
        }

        public void IncrementQuestionIndex()
        {
            currentQuestionIndex++;
        }
    }
}
//////////////////////////////////////////////////////////////////// END OF CLASS ////////////////////////////////////////////////////////////////////
