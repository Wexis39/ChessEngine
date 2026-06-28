using ChessEngine.ChessEngineCore.Board;
using System.Drawing;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class formSettings
    {
        public static Panel mainPanel = new Panel();
        public static Label lblTurn = new Label();
        public static void _formSettings(Form1 frm)
        {
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = new Size(640, 670);
            chessMainPanel(frm);
        }
        public static void chessMainPanel(Form1 frm)
        {
            mainPanel.Size = new Size(640, 670);
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            frm.Controls.Add(mainPanel);

            lblTurn.Location = new Point(700, 50);
            lblTurn.ForeColor = Color.Black;
            lblTurn.Text = boardData.turnColor.ToString();
            frm.Controls.Add(lblTurn);
        }
        public static void updateLabel()
        {
            lblTurn.Text = boardData.turnColor.ToString();
        }
    }
}