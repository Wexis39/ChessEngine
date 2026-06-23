using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class buttonEvents
    {
        public static void buttonClickEvent(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            boardData.selectedSquareButton = btn;
            boardData.selectedSquareIndex = btn.Name;
            findPieceFromButtonIndex();
            showValidMoves();
        }
        public static void findPieceFromButtonIndex()
        {
            int posRow = Convert.ToInt32(boardData.selectedSquareIndex[0].ToString());
            int posCol = Convert.ToInt32(boardData.selectedSquareIndex[1].ToString());
            boardData.selectedPiece = boardData.piecesBoardData[posRow, posCol];
            boardData.selectedPieceIndex = boardData.selectedPiece?.pieceId??null;
        }
        public static void showValidMoves()
        {
            if (boardData.selectedPiece != null)
            {
                boardData.selectedPiece.GetValidMoves();
                boardColorEvents.restoreBoardColors();
                boardColorEvents.colorValidMoves();
            }
            else
            {
                boardColorEvents.restoreBoardColors();
            }
        }
    }
}
