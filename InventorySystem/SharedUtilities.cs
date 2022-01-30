using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    internal static class SharedUtilities
    {
        /// <summary>
        /// Validates the Text of a TextBox to match the System.Text.RegularExpressions.Regex expression passed along with it.
        /// </summary>
        /// <param name="textSender">A TextBox control</param>
        /// <param name="expression">A string regex pattern to validate the TextBox.Text against</param>
        internal static void ValidateTextBoxInt(TextBox textSender, Regex expression)
        {
            if (expression.IsMatch(textSender.Text))
            {
                var sanatizedTextBuilder = new StringBuilder("");
                var currentPos = textSender.SelectionStart;
                foreach (var ch in textSender.Text)
                {
                    // If 'not'. This loop is mainly here in case a user pastes text instead of typing in a letter at a time
                    if (!expression.IsMatch(ch.ToString()))
                    {
                        sanatizedTextBuilder.Append(ch);
                    }
                }
                textSender.Text = sanatizedTextBuilder.ToString();
                // Forcibly setting the text above puts the cursor back at the beginning. For user experience, 
                // reset the cursor back to where it was - 1 (as the latest character was invalid).
                try
                {
                    textSender.SelectionStart = currentPos - 1;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Sometimes the currentPos is 0, can't do 0 - 1
                    textSender.SelectionStart = currentPos;
                }
                textSender.SelectionLength = 0;
            }
        }
    }
}
