using ChessEngine.ChessEngineCore.Board;
using System.Drawing;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class formSettings
    {
        public static Panel mainPanel = new Panel();
        public static Label lbl = new Label();
        public static void _formSettings(Form1 frm)
        {
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = new Size(1_000, 670);
            chessMainPanel(frm);
        }
        public static void chessMainPanel(Form1 frm)
        {
            mainPanel.Size = new Size(640, 670);
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            frm.Controls.Add(mainPanel);

            //-----------------------
            
            lbl.Location = new Point(700, 50);
            lbl.ForeColor = Color.Black;
            lbl.Text = boardData.turnColor.ToString();
            frm.Controls.Add(lbl);
        }
        public static void updateLabel()
        {
            lbl.Text = boardData.turnColor.ToString();
        }
    }
}