using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ST10081800_PROG7312_POE
{
    public partial class AppMenu : Form
    {
        public AppMenu()
        {
            InitializeComponent();
        }

        Game gameHere = new Game();
        MatchingGame matchHere = new MatchingGame();
        DWC_Quiz dwc = new DWC_Quiz();

        #region
        /// <summary>
        /// Menu option to select either to replace books,
        /// identify books, or finding call numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (bookReplacementBtn.Checked)
            {
                gameHere.ShowDialog();
            }
            else if (identifyAreaBtn.Checked)
            {
                matchHere.ShowDialog();
            }
            else if (findingCallNumbersBtn.Checked)
            {
                dwc.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have not made selection.");
                return;
            }
            //Closing current form when navigating to the next form
            this.Close();
        }
        #endregion

        #region
        /// <summary>
        /// Stopping an application from running when closing button is clicked
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }
        #endregion
    }
}
///////////////////////////////////// END OF CLASS /////////////////////////////////////
