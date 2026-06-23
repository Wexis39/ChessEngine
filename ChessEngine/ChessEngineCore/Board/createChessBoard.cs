using ChessEngine.ChessEngineCore.Board;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class createChessBoard
    {
        public static void _createChessBoard(Form1 frm)
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
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Click += buttonEvents.buttonClickEvent;
                    //btn.Text=$"{i}{j}";
                    if ((i + j) % 2 == 1)
                    {
                        btn.BackColor = Color.FromArgb(194, 131, 78);
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(239, 206, 161);
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