using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class updateChessBoardUI
    {
        public static void _updateChessBoardUI(Form1 frm)
        {
            for (int i = 0; i < formSettings.mainPanel.Controls.Count; i++)
            {
                Button btn = formSettings.mainPanel.Controls[i] as Button;
                string btnFullIndex = btn.Name;
                int indexX = Convert.ToInt32(btnFullIndex[0].ToString());
                int indexY = Convert.ToInt32(btnFullIndex[1].ToString());
                Piece piece = boardData.piecesBoardData[indexX, indexY];
                if (piece!=null)
                {
                    btn.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(piece.fullImagePath);
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
    }
}
