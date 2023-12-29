using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10081800_PROG7312_POE.Model
{
    public class Book
    { 
        static List<string> callNumbers = new List<string>();
        public bool isTrue = false;

        #region
        /// <summary>
        /// Sorting numbers in ascending order
        /// </summary>
        /// <returns></returns>
        public List<String> arrange()
        {
            callNumbers.Sort();

            isTrue = true;
            return callNumbers;
        }
        #endregion

        #region
        /// <summary>
        /// Generating random numbers
        /// </summary>
        /// <returns></returns>
        public static  List<string> GenerateCallNumbers()
        {
            Random random = new Random();
            if(callNumbers.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    int topicNumber = random.Next(1000);
                    string authorName = GenerateAuthorName();

                    string callNumber = $"{topicNumber:000}.00 {authorName.ToUpper()}";
                    //Adding call numbers in a list
                    callNumbers.Add(callNumber);
                }
            }
            return callNumbers;
        }
        #endregion

        #region
        /// <summary>
        /// Generating Author's last names
        /// </summary>
        static Random random = new Random();
        static string GenerateAuthorName()
        {
            //Using arrary to store author's last names
            string[] lastNames = { "Smith", "Johnson", "Brown", "Taylor", "Iteta", "Wilson", "Banda", "Anderson", "Jackson", "Lee" };

            string lastName = lastNames[random.Next(lastNames.Length)];

            return lastName.Substring(0, Math.Min(3, lastName.Length));
        }
        #endregion

        #region
        /// <summary>
        /// Display call numbers
        /// </summary>
        /// <param name="callNumbers"></param>
        /// <returns></returns>
        public static string DisplayCallNumbers(List<string> callNumbers)
        {
            StringBuilder stringBuilderHere = new StringBuilder();
            string num = "";
            for (int i = 0; i < callNumbers.Count; i++)
            {
                GenerateAuthorName();
                num += $"{callNumbers[i]} \n";
            }
            return num; 
        }
        #endregion
    }
}
//////////////////////////////////////////////// END OF CLASS ////////////////////////////////////////////////