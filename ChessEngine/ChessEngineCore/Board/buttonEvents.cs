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
                if (controlTurnColor())
                {
                    makeMoveEvent();
                }
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
            //boardData.selectedPiece.pieceColor == boardData.turnColor ADDED
            if (boardData.selectedPiece != null && boardData.selectedPiece.pieceColor == boardData.turnColor)
            {
                boardData.selectedPiece.GetValidMoves();
                boardColorEvents.restoreBoardColors();
                boardColorEvents.colorBoard();
            }
            else
            {
                boardColorEvents.restoreBoardColors();
            }
        }
        public static void makeMoveEvent()
        {
            if (boardData.selectedPiece.validPosArr.Contains(boardData.selectedSquareIndex))
            {
                applyMove();
            }
            if (!boardData.isAnyDatasNull())
            {
                if (boardData.selectedPiece.capturesPosArr != null)
                {
                    if (boardData.selectedPiece.capturesPosArr.Contains(boardData.selectedSquareIndex))
                    {
                        if (boardData.enPassantCapturesArr.Count != 0 && boardData.enPassantCapturesArr!=null)
                        {
                            boardData.clearEnPassantCapturesArr();
                        }
                        applyMove();
                    }
                }
            }
            //-----LABEL-----
            formSettings.updateLabel();
        }
        public static void applyMove()
        {
            int posX = Convert.ToInt32(boardData.selectedSquareIndex[0].ToString());
            int posY = Convert.ToInt32(boardData.selectedSquareIndex[1].ToString());
            int tempPosX = boardData.selectedPiece.posRow;
            int tempPosY = boardData.selectedPiece.posCol;
            boardData.piecesBoardData[posX, posY] = boardData.selectedPiece;
            boardData.selectedPiece.pieceId = (posX.ToString() + posY.ToString());
            boardData.selectedPiece.setPositionFromId();
            boardData.piecesBoardData[tempPosX, tempPosY] = null;
            afterMoveEvent();
        }
        public static void afterMoveEvent()
        {
            updateChessBoardUI._updateChessBoardUI();
            boardData.isAnyPieceSelected = false;
            afterMoveResetSelecteds();
            boardColorEvents.restoreBoardColors();
            changeColor();
        }
        public static void afterMoveResetSelecteds()
        {
            boardData.selectedSquareButton = null;
            boardData.selectedSquareIndex = null;
            boardData.selectedPiece = null;
            boardData.selectedPieceIndex = null;
        }
        public static void changeColor()
        {
            if (boardData.turnColor == Piece.pieceColorEnum.Black)
            {
                boardData.turnColor = Piece.pieceColorEnum.White;
                boardData.blackMoveCount++;
            }
            else
            {
                boardData.turnColor = Piece.pieceColorEnum.Black;
                boardData.whiteMoveCount++;
            }
        }
        public static bool controlTurnColor()
        {
            if (boardData.selectedPiece.pieceColor == boardData.turnColor)
            {
                return true;
            }
            return false;
        }
    }
}
