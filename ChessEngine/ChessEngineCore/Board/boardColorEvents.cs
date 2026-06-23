using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class boardColorEvents
    {
        public static void colorValidMoves()
        {
            string[] moveArray=boardData.selectedPiece.validPosArr;

            colorSelectedSquare();
            if (moveArray != null)
            {
                for (int i = 0; i < formSettings.mainPanel.Controls.Count; i++)
                {
                    Button btn = formSettings.mainPanel.Controls[i] as Button;
                    if (moveArray.Contains(btn.Name))
                    {
                        if (btn.BackColor == Color.FromArgb(194, 131, 78))
                        {
                            btn.BackColor = Color.FromArgb(134, 179, 85);
                        }
                        else if (btn.BackColor == Color.FromArgb(239, 206, 161))
                        {
                            btn.BackColor = Color.FromArgb(163, 206, 105);
                        }
                    }
                }
            }
        }
        public static void colorSelectedSquare()
        {
            Color oldColor = boardData.selectedSquareButton.BackColor;
            boardData.selectedSquareButton.BackColor = Color.FromArgb(110, 130, 80);
        }
        public static void restoreBoardColors()
        {
            int x = 0;
            for (int i=0; i<64; i++)
            {
                if (i%8 == 0)
                {
                    x += 1;
                }
                Button btn = formSettings.mainPanel.Controls[i] as Button;
                if ((x+i)%2 == 0)
                {
                    btn.BackColor = Color.FromArgb(194, 131, 78);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(239, 206, 161);
                }
            }
        }
    }
}
