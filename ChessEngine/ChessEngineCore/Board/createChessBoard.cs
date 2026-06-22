using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class createChessBoard
    {
        public static void _createChessBoard(Form frm)
        {
            int locationX = 0;
            int locationY = 30;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button btn = new Button();
                    btn.Name = $"{i}{j}";
                    btn.Size = new System.Drawing.Size(80, 80);
                    btn.Location = new System.Drawing.Point(locationX, locationY);
                    btn.Text = btn.Name;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatStyle = FlatStyle.Flat;
                    if ((i + j) % 2 == 1)
                    {
                        btn.BackColor = Color.FromArgb(118, 150, 86);
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(238, 238, 210);
                    }
                    formSettings.mainPanel.Controls.Add(btn);
                    locationX += 80;
                }
                locationX = 0;
                locationY += 80;
            }
        }
    }
}