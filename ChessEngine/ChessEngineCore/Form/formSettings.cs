using System.Drawing;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class formSettings
    {
        public static Panel mainPanel = new Panel();
        public static void _formSettings(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = new Size(1_000, 670);
            chessMainPanel(frm);
        }
        public static void chessMainPanel(Form frm)
        {
            mainPanel.Size = new Size(640, 670);
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            frm.Controls.Add(mainPanel);
        }
    }
}