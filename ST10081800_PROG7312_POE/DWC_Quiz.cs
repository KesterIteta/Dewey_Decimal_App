using ST10081800_PROG7312_POE.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ST10081800_PROG7312_POE
{
    public partial class DWC_Quiz : Form
    {
        private CallNumbersTree CallNumbersData { get; set; }
        private Random Rand = new Random();
        private CallNumberCategoryFirstLevel FirstLevel { get; set; }
        private CallNumberCategorySecondLevel SecondLevel { get; set; }
        private CallNumberCategoryThirdLevel ThirdLevel { get; set; }
        private System.Windows.Forms.RadioButton CorrectButton { get; set; }
        private GameState CurrentState { get; set; }
        private int HighScore { get; set; } = 0;
        private int CurrentScore { get; set; } = 0;

        public DWC_Quiz()
        {
            InitializeComponent();
            LoadData();
            Setup();
        }

        #region
        /// <summary>
        /// For setup we need to pick a third level option, so we pick a random first level, then a random second level, then finally a random third level entry
        /// </summary>
        private void Setup()
        {
            UpdateScore();
            PickQuestion();
            SetUpOptions();
        }
        #endregion

        #region
        /// <summary>
        /// To update score
        /// </summary>
        private void UpdateScore()
        {
            if (CurrentScore > HighScore)
            {
                HighScore = CurrentScore;
            }
            currentScoreLabel.Text = $"Current Score: {CurrentScore}";
            highScoreLabel.Text = $"High Score: {HighScore}";
        }
        #endregion

        #region
        /// <summary>
        /// Picking question between first level, second level and third level
        /// </summary>
        private void PickQuestion()
        {
            CurrentState = GameState.FIRST_LEVEL;
            FirstLevel = CallNumbersData.categories[Rand.Next(0, CallNumbersData.categories.Count)];
            SecondLevel = FirstLevel.subcategories[Rand.Next(0, FirstLevel.subcategories.Count)];
            ThirdLevel = SecondLevel.subcategories[Rand.Next(0, SecondLevel.subcategories.Count)];
            questionLabel.Text = ThirdLevel.description;
        }
        #endregion

        #region
        /// <summary>
        /// To choose between buttons
        /// </summary>
        private void SetUpOptions()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            if (CurrentState == GameState.FIRST_LEVEL)
            {
                List<CallNumberCategoryFirstLevel> options = new List<CallNumberCategoryFirstLevel>(new CallNumberCategoryFirstLevel[] { FirstLevel });
                options = options.OrderBy(option => option.code).ToList();
                do
                {
                    int random = Rand.Next(0, CallNumbersData.categories.Count);
                    if (!options.Contains(CallNumbersData.categories[random]))
                    {
                        options.Add(CallNumbersData.categories[random]);
                    }
                }
                while (options.Count < 4);
                options = RandomizeList(options);
                //Display options in numerical order by call numbers
                options = options.OrderBy(option => option.code).ToList();
                radioButton1.Text = $"{options[0].code} {options[0].description}";
                if (options[0] == FirstLevel) { CorrectButton = radioButton1; }
                radioButton2.Text = $"{options[1].code} {options[1].description}";
                if (options[1] == FirstLevel) { CorrectButton = radioButton2; }
                radioButton3.Text = $"{options[2].code} {options[2].description}";
                if (options[2] == FirstLevel) { CorrectButton = radioButton3; }
                radioButton4.Text = $"{options[3].code} {options[3].description}";
                if (options[3] == FirstLevel) { CorrectButton = radioButton4; }
            }
            else if (CurrentState == GameState.SECOND_LEVEL)
            {
                List<CallNumberCategorySecondLevel> options = new List<CallNumberCategorySecondLevel>(new CallNumberCategorySecondLevel[] { SecondLevel });
                
                do
                {
                    int random = Rand.Next(0, FirstLevel.subcategories.Count);
                    if (!options.Contains(FirstLevel.subcategories[random]))
                    {
                        options = options.OrderBy(option => option.code).ToList();
                        options.Add(FirstLevel.subcategories[random]);
                    }
                }
                while (options.Count < 4);
                options = RandomizeList(options);
                //Display options in numerical order by call numbers
                options = options.OrderBy(option => option.code).ToList();
                radioButton1.Text = $"{options[0].code} {options[0].description}";
                if (options[0] == SecondLevel) { CorrectButton = radioButton1; }
                radioButton2.Text = $"{options[1].code} {options[1].description}";
                if (options[1] == SecondLevel) { CorrectButton = radioButton2; }
                radioButton3.Text = $"{options[2].code} {options[2].description}";
                if (options[2] == SecondLevel) { CorrectButton = radioButton3; }
                radioButton4.Text = $"{options[3].code} {options[3].description}";
                if (options[3] == SecondLevel) { CorrectButton = radioButton4; }
            }
            else if (CurrentState == GameState.THIRD_LEVEL)
            {

                List<CallNumberCategoryThirdLevel> options = new List<CallNumberCategoryThirdLevel>(new CallNumberCategoryThirdLevel[] { ThirdLevel });
                do
                {
                    int random = Rand.Next(0, SecondLevel.subcategories.Count);
                    if (!options.Contains(SecondLevel.subcategories[random]))
                    {
                        options.Add(SecondLevel.subcategories[random]);
                    }
                }
                while (options.Count < 4);
                options = RandomizeList(options);
                //Display options in numerical order by call numbers
                options = options.OrderBy(option => option.code).ToList();
                radioButton1.Text = $"{options[0].code} {options[0].description}";
                if (options[0] == ThirdLevel) { CorrectButton = radioButton1; }
                radioButton2.Text = $"{options[1].code} {options[1].description}";
                if (options[1] == ThirdLevel) { CorrectButton = radioButton2; }
                radioButton3.Text = $"{options[2].code} {options[2].description}";
                if (options[2] == ThirdLevel) { CorrectButton = radioButton3; }
                radioButton4.Text = $"{options[3].code} {options[3].description}";
                if (options[3] == ThirdLevel) { CorrectButton = radioButton4; }
            }
        }
        #endregion

        #region
        /// <summary>
        /// Using submit button after user selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, EventArgs e)
        {
            //If no options were selected
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("You have not made a selection");
            }
            else if (CurrentState == GameState.FIRST_LEVEL)
            {
                if (CorrectButton.Checked)
                {
                    CurrentState = GameState.SECOND_LEVEL;
                }
                else
                {
                    CurrentScore = 0;
                    MessageBox.Show($"You have chosen the incorrect option.{Environment.NewLine}Correct option was {FirstLevel.code} {FirstLevel.description}");
                    PickQuestion();
                }
            }
            else if (CurrentState == GameState.SECOND_LEVEL)
            {
                if (CorrectButton.Checked)
                {
                    CurrentState = GameState.THIRD_LEVEL;
                }
                else
                {
                    CurrentScore = 0;
                    MessageBox.Show($"You have chosen the incorrect option.{Environment.NewLine}Correct option was {SecondLevel.code} {SecondLevel.description}");
                    PickQuestion();
                }
            }
            else if (CurrentState == GameState.THIRD_LEVEL)
            {
                if (CorrectButton.Checked)
                {
                    CurrentScore += 10;
                    MessageBox.Show($"Well done!");
                }
                else
                {
                    CurrentScore = 0;
                    MessageBox.Show($"You have chosen the incorrect option.{Environment.NewLine}Correct option was {ThirdLevel.code} {ThirdLevel.description}");
                }
                PickQuestion();
            }
            UpdateScore();
            SetUpOptions();
        }
        #endregion

        #region
        /// <summary>
        /// Method used to load data
        /// </summary>
        private void LoadData()
        {
            string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "callNumbers.json");
            string json = File.ReadAllText(dataPath);
            CallNumbersData = JsonSerializer.Deserialize<CallNumbersTree>(json);
        }
        #endregion

        #region
        /// <summary>
        /// Selecting random input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList"></param>
        /// <returns></returns>
        static List<T> RandomizeList<T>(List<T> inputList)
        {
            List<T> randomizedList = new List<T>(inputList);
            Random random = new Random();

            int n = randomizedList.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = randomizedList[k];
                randomizedList[k] = randomizedList[n];
                randomizedList[n] = value;
            }
            return randomizedList;
        }
        #endregion

        #region
        /// <summary>
        /// Closind an application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }
        #endregion

        #region
        /// <summary>
        /// To find data to to answer correct questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use callNumbers.json file data \nto find correct answers!");
        }
        #endregion
    }
}
///////////////////////////////////////////  END OF CLASS ///////////////////////////////////////////

