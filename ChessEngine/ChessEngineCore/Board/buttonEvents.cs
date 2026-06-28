using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessEngine.ChessEngineCore.Pieces;
using static ChessEngine.ChessEngineCore.Piece;

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
            if (boardData.selectedSquareIndex != null)
            {
                findPieceFromButtonIndex();
            }
            showValidMoves();

            boardData.isAnyPieceSelected = (boardData.selectedPiece != null && boardData.selectedPiece.validPosArr != null);
        }

        public static void findPieceFromButtonIndex()
        {
            int posRow = Convert.ToInt32(boardData.selectedSquareIndex[0].ToString());
            int posCol = Convert.ToInt32(boardData.selectedSquareIndex[1].ToString());
            boardData.selectedPiece = boardData.piecesBoardData[posRow, posCol];
            boardData.selectedPieceIndex = boardData.selectedPiece?.pieceId ?? null;
        }

        public static void showValidMoves()
        {
            if (boardData.selectedPiece != null && boardData.selectedPiece.pieceColor == boardData.turnColor)
            {
                chessLogicFuncs.kingInCheckMoves(boardData.selectedPiece);
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
            if (boardData.selectedPiece == null) return;

            bool isLegalMove = (boardData.selectedPiece.validPosArr != null && boardData.selectedPiece.validPosArr.Contains(boardData.selectedSquareIndex)) ||
                               (boardData.selectedPiece.capturesPosArr != null && boardData.selectedPiece.capturesPosArr.Contains(boardData.selectedSquareIndex));

            if (isLegalMove)
            {
                applyMove();
                allPossibleMoveData.calculatePossibeMoves();
                chessLogicFuncs.isKingInCheck();
                chessLogicFuncs.checkGameOver();
                afterMoveEvent();
            }
        }

        public static void applyMove()
        {
            if (boardData.selectedPiece == null) return;

            int posX = Convert.ToInt32(boardData.selectedSquareIndex[0].ToString());
            int posY = Convert.ToInt32(boardData.selectedSquareIndex[1].ToString());
            int tempPosX = boardData.selectedPiece.posRow;
            int tempPosY = boardData.selectedPiece.posCol;

            if (boardData.selectedPiece.pieceType == pieceTypeEnum.King && Math.Abs(posY - tempPosY) == 2)
            {
                int rookCol = (posY - tempPosY > 0) ? 7 : 0;
                int newRookCol = (posY - tempPosY > 0) ? 5 : 3;
                Piece rook = boardData.piecesBoardData[posX, rookCol];
                boardData.piecesBoardData[posX, newRookCol] = rook;
                rook.pieceId = posX.ToString() + newRookCol.ToString();
                rook.setPositionFromId();
                rook.hasMoved = true;
                boardData.piecesBoardData[posX, rookCol] = null;
            }

            if (boardData.selectedPiece.capturesPosArr != null && boardData.selectedPiece.capturesPosArr.Contains(boardData.selectedSquareIndex))
            {
                if (boardData.enPassantCapturesArr != null && boardData.enPassantCapturesArr.Contains(posX.ToString() + posY.ToString()))
                {
                    int capturedRow = (boardData.selectedPiece.pieceColor == pieceColorEnum.White) ? posX + 1 : posX - 1;
                    boardData.piecesBoardData[capturedRow, posY] = null;
                }
                boardData.clearEnPassantCapturesArr();
            }

            boardData.piecesBoardData[posX, posY] = boardData.selectedPiece;
            boardData.selectedPiece.pieceId = (posX.ToString() + posY.ToString());
            setKingIndex(boardData.selectedPiece, posX, posY);
            boardData.selectedPiece.setPositionFromId();
            boardData.selectedPiece.hasMoved = true;
            boardData.piecesBoardData[tempPosX, tempPosY] = null;

            if (boardData.selectedPiece.pieceType == pieceTypeEnum.Pawn && (posX == 0 || posX == 7))
            {
                PromotionForm pForm = new PromotionForm(boardData.selectedPiece.pieceColor);
                pForm.ShowDialog();
                Piece newPromotedPiece = null;

                if (pForm.selectedType == pieceTypeEnum.Queen)
                    newPromotedPiece = new ChessEngine.ChessEngineCore.Pieces.Queen(boardData.selectedPiece.pieceColor);
                else if (pForm.selectedType == pieceTypeEnum.Rook)
                    newPromotedPiece = new ChessEngine.ChessEngineCore.Pieces.Rook(boardData.selectedPiece.pieceColor);
                else if (pForm.selectedType == pieceTypeEnum.Bishop)
                    newPromotedPiece = new ChessEngine.ChessEngineCore.Pieces.Bishop(boardData.selectedPiece.pieceColor);
                else if (pForm.selectedType == pieceTypeEnum.Knight)
                    newPromotedPiece = new ChessEngine.ChessEngineCore.Pieces.Knight(boardData.selectedPiece.pieceColor);

                if (newPromotedPiece != null)
                {
                    newPromotedPiece.pieceId = posX.ToString() + posY.ToString();
                    newPromotedPiece.setPositionFromId();
                    newPromotedPiece.hasMoved = true;
                    boardData.piecesBoardData[posX, posY] = newPromotedPiece;
                    boardData.selectedPiece = newPromotedPiece;
                }
            }
        }

        public static void setKingIndex(Piece piece, int newPosX, int newPosY)
        {
            if (piece.pieceType == pieceTypeEnum.King)
            {
                if (piece.pieceColor == pieceColorEnum.White)
                {
                    boardData.whiteKingIndexX = newPosX;
                    boardData.whiteKingIndexY = newPosY;
                }
                else
                {
                    boardData.blackKingIndexX = newPosX;
                    boardData.blackKingIndexY = newPosY;
                }
            }
        }

        public static void afterMoveEvent()
        {
            updateChessBoardUI._updateChessBoardUI();
            boardColorEvents.restoreBoardColors();
            changeColor();
            formSettings.updateLabel();
            afterMoveResetSelecteds();
            chessLogicFuncs.checkGameOver();
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
            boardData.turnColor = (boardData.turnColor == pieceColorEnum.White) ? pieceColorEnum.Black : pieceColorEnum.White;
            if (boardData.turnColor == pieceColorEnum.White) boardData.whiteMoveCount++;
            else boardData.blackMoveCount++;
        }

        public static bool controlTurnColor()
        {
            return boardData.selectedPiece != null && boardData.selectedPiece.pieceColor == boardData.turnColor;
        }
    }
}