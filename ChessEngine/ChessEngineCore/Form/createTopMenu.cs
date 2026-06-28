using System.Drawing;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class createTopMenu
    {
        static bool isDragging = false;
        static Point startLocation = new Point(0, 0);
        public static void _createTopMenu(Form1 frm)
        {
            Panel panel = new Panel();
            Button closeBtn = new Button();
            Button hideBtn = new Button();
            Label projectNameLabel = new Label();

            projectNameLabel.Text = "Chess Engine";
            projectNameLabel.ForeColor = Color.Black;
            projectNameLabel.Location = new Point(0, 8);
            projectNameLabel.AutoSize = true;
            projectNameLabel.Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            projectNameLabel.Enabled = false;

            closeBtn.Text = "X";
            closeBtn.Size = new Size(30, 30);
            closeBtn.ForeColor = Color.White;
            closeBtn.BackColor = Color.Red;
            closeBtn.Location = new Point(610, 0);
            closeBtn.Font = new Font(FontFamily.GenericMonospace, 14, FontStyle.Bold);
            closeBtn.Click += (s, e) => { frm.Close(); };

            hideBtn.Text = "-";
            hideBtn.Size = new Size(30, 30);
            hideBtn.ForeColor = Color.Black;
            hideBtn.BackColor = Color.WhiteSmoke;
            hideBtn.Location = new Point(580, 0);
            hideBtn.Font = new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold);
            hideBtn.Click += (s, e) => { frm.WindowState = FormWindowState.Minimized; };

            panel.BackColor = Color.FromArgb(255, 255, 240);
            panel.Size = new Size(640, 30);
            panel.Location = new Point(0, 0);
            panel.Controls.Add(closeBtn);
            panel.Controls.Add(hideBtn);
            panel.Controls.Add(projectNameLabel);

            panel.MouseDown += (s, e) => { isDragging = true; startLocation = new Point(e.X, e.Y); };
            panel.MouseUp += (s, e) => { isDragging = false; };
            panel.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point cursorPoint = Cursor.Position;
                    frm.Location = new Point(cursorPoint.X - startLocation.X, cursorPoint.Y - startLocation.Y);
                }
            };
            frm.Controls.Add(panel);
        }
    }
}