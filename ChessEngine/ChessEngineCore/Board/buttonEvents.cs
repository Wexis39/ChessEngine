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

            if (boardData.isAnyPieceSelected == true)
            {
                makeMove();
            }
            //else
            //{
            //    findPieceFromButtonIndex();
            //    showValidMoves();

            //    if (boardData.selectedPiece != null && boardData.selectedPiece.validPosArr != null)
            //    {
            //        boardData.isAnyPieceSelected = true;
            //    }
            //    else
            //    {
            //        boardData.isAnyPieceSelected = false;
            //    }
            //}
            if(boardData.selectedSquareIndex != null)
            {
                findPieceFromButtonIndex();
            }
            showValidMoves();

            if (boardData.selectedPiece != null && boardData.selectedPiece.validPosArr != null)
            {
                boardData.isAnyPieceSelected = true;
            }
            else
            {
                boardData.isAnyPieceSelected = false;
            }
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
        public static void makeMove()
        {
            if (boardData.selectedPiece.validPosArr.Contains(boardData.selectedSquareIndex))
            {
                int posX = Convert.ToInt32(boardData.selectedSquareIndex[0].ToString());
                int posY = Convert.ToInt32(boardData.selectedSquareIndex[1].ToString());
                int tempPosX = boardData.selectedPiece.posRow;
                int tempPosY = boardData.selectedPiece.posCol;
                boardData.piecesBoardData[posX, posY] = boardData.selectedPiece;
                boardData.selectedPiece.pieceId = (posX.ToString() + posY.ToString());
                boardData.selectedPiece.setPositionFromId();
                boardData.piecesBoardData[tempPosX, tempPosY] = null;

                updateChessBoardUI._updateChessBoardUI();
                boardData.isAnyPieceSelected = false;
                afterMoveResetSelecteds();
                boardColorEvents.restoreBoardColors();
            }
        }
        public static void afterMoveResetSelecteds()
        {
            boardData.selectedSquareButton = null;
            boardData.selectedSquareIndex = null;
            boardData.selectedPiece = null;
            boardData.selectedPieceIndex = null;
        }
    }
}
