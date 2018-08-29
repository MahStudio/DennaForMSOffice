using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

namespace Denna.Office.Word
{
    public partial class ThisAddIn
    {
        private MasterView _view;
        private Microsoft.Office.Tools.CustomTaskPane _myCustomTaskPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _view = new MasterView();
            _myCustomTaskPane = this.CustomTaskPanes.Add(_view, "Denna");
            _myCustomTaskPane.Visible = true;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
