using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MangaReader.MessageBoxes.LastFirst;

namespace MangaReader.MessageBoxes
{
    internal class YesNoDialog {

        internal static bool AskForAction(LastFirstObj actionObj) {
            String caption = "End or Beginning of Session";
            MessageBoxButtons confirmation = MessageBoxButtons.YesNo;

            DialogResult res = MessageBox.Show(actionObj.getMessage(), caption, confirmation);

            return (res == DialogResult.Yes) ? actionObj.YesAction() : 
                                               actionObj.NoAction();
        }
    }
}
