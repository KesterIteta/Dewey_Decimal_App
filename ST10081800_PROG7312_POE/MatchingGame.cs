using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DeweyDecimalLibrary;
using CustomControlsClassLibrary;

namespace ST10081800_PROG7312_POE
{
    public partial class MatchingGame : Form
    {
        private DeweyDecimalClass deweyDecimal;

        private List<CustomButtonClass> callNumberBtns, descriptionBtns;

        private bool callNumberFirst;


        public MatchingGame()
        {
            InitializeComponent();
            this.deweyDecimal = new DeweyDecimalClass();
            callNumberBtns = new List<CustomButtonClass>
            {
                callNumberBtn1,
                callNumberBtn2,
                callNumberBtn3,
                callNumberBtn4
            };

            descriptionBtns = new List<CustomButtonClass>
            {
                descriptionBtn1,
                descriptionBtn2,
                descriptionBtn3,
                descriptionBtn4,
                descriptionBtn5,
                descriptionBtn6,
                descriptionBtn7,
            };
            callNumberFirst = false;

            Console.WriteLine("Hellow world! app is running");
            GenerateQuestionSet();
        }

        #region
        /// <summary>
        /// Generating list of questions stored in a list and dictionary
        /// </summary>
        private void GenerateQuestionSet()
        {
            if (this.deweyDecimal.GetCurrentQuestionIndex() % 1 == 0)
            {
                callNumberFirst = !callNumberFirst;
            }

            this.deweyDecimal.GenerateQuestionSet(callNumberFirst);

            Console.WriteLine($"There are {this.deweyDecimal.GetCallNumbers().Count} call numbers");
            Console.WriteLine($"There are {this.deweyDecimal.GetDescriptions().Count} call descriptions");
            Console.WriteLine($"There are {callNumberBtns.Count} CallNumber buttons");
            Console.WriteLine($"There are {descriptionBtns.Count} Description buttons");

            // Enable the call number buttons and disable the description buttons
            foreach (var button in callNumberBtns)
            {
                button.Enabled = true;
            }

            foreach (var button in descriptionBtns)
            {
                button.Enabled = true;
            }

            var questionCallNumbers = this.deweyDecimal.GetCallNumbers();
            var questionDescriptions = this.deweyDecimal.GetDescriptions();

            // Set the text of the call number buttons and description buttons
            for (var i = 0; i < 4; i++)
            {
                if (callNumberFirst)
                    callNumberBtns[i].Text = questionCallNumbers[i];
                else
                    callNumberBtns[i].Text = questionDescriptions[i];
            }

            for (var i = 0; i < 7; i++)
            {
                if (callNumberFirst)
                    descriptionBtns[i].Text = questionDescriptions[i];
                else
                    descriptionBtns[i].Text = questionCallNumbers[i];
            }

            // Set the text of the score label and question number label
            quesNumberLabel.Text = $"Question: {this.deweyDecimal.GetCurrentQuestionIndex()}";
            scoreLabel.Text = $"Points: {this.deweyDecimal.GetScore()}";
        }
        #endregion

        #region
        private void CallNumberButton_MouseDown(object sender, MouseEventArgs e)
        {
            var button = (CustomButtonClass)sender;
            string callNumber = button.Text;

            // Start the drag-and-drop operation with the call number button as the data
            button.DoDragDrop(callNumber, DragDropEffects.Move);
        }

        private void DescriptionButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is CustomButtonClass button)
            {
                button.DoDragDrop(button, DragDropEffects.Move);

            }
        }
        #endregion

        #region
        /// <summary>
        /// Using drag enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CustomButtonClass)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion

        #region
        /// <summary>
        /// Dragging the buttons over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CustomButtonClass)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        #endregion

        #region
        /// <summary>
        /// Verifying the the answer if it is correct or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verifyAnswers_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (callNumberFirst)
                    {
                        if (this.deweyDecimal.CheckAnswer(callNumberBtns[i].Text, descriptionBtns[i].Text) == false)
                        {
                            MessageBox.Show("Incorrect.");
                            return;
                        }
                    }
                    else
                    {
                        if (this.deweyDecimal.CheckAnswer(descriptionBtns[i].Text, callNumberBtns[i].Text) == false)
                        {
                            MessageBox.Show("Incorrect.");
                            return;
                        }
                    }
                }
                MessageBox.Show("Correct.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        #endregion

        #region
        /// <summary>
        /// Use next button to play next game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextBtn_Click(object sender, EventArgs e)
        {
            bool allCorrect = true;
            for (int i = 0; i < 4; i++)
            {
                if (callNumberFirst)
                {
                    if (this.deweyDecimal.CheckAnswer(callNumberBtns[i].Text, descriptionBtns[i].Text) == false)
                    {
                        allCorrect = false;
                    }
                }
                else
                {
                    if (this.deweyDecimal.CheckAnswer(descriptionBtns[i].Text, callNumberBtns[i].Text) == false)
                    {
                        allCorrect = false;
                    }
                }
            }

            if (allCorrect)
            {
                this.deweyDecimal.IncrementScore();
            }
            this.GenerateQuestionSet();
        }
        #endregion

        #region
        /// <summary>
        /// Panel to hold answer buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerPanel_DragDrop(object sender, DragEventArgs e)
        {
            var targetButton = (CustomButtonClass)sender;

            // Check if the dragged data is of type CustomButtonClass
            if (e.Data.GetDataPresent(typeof(CustomButtonClass)))
            {
                CustomButtonClass sourceButton = (CustomButtonClass)e.Data.GetData(typeof(CustomButtonClass));

                if (sourceButton != null && targetButton != null)
                {
                    var temp = targetButton.Text;
                    targetButton.Text = sourceButton.Text;
                    sourceButton.Text = temp;
                }
            }
        }
        #endregion
    }
}
//////////////////////////////////////////////////////////////////// END OF CLASS ////////////////////////////////////////////////////////////////////

