using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class King : Piece
    {
        public King(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.King;
        }

        public override void allPossibleMoves(Piece[,] board = null)
        {
            capturesPosArr = new List<string>();
            GetValidMoves();
        }

        public override void GetValidMoves()
        {
            validPosArr = new List<string>();
            sendAllMovesToFunc();
            checkCastling();
        }

        public void sendAllMovesToFunc()
        {
            checkMoveFunction(-1, 0);
            checkMoveFunction(-1, 1);
            checkMoveFunction(0, 1);
            checkMoveFunction(1, 1);
            checkMoveFunction(1, 0);
            checkMoveFunction(1, -1);
            checkMoveFunction(0, -1);
            checkMoveFunction(-1, -1);
        }

        public void checkMoveFunction(int indexRow, int indexCol)
        {
            int newRow = posRow + indexRow;
            int newCol = posCol + indexCol;
            if ((newRow <= 7 && newRow >= 0) && (newCol <= 7 && newCol >= 0))
            {
                if (boardData.isBlockingAnyPiece(newRow, newCol))
                {
                    validPosArr.Add(newRow.ToString() + newCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newRow, newCol))
                    {
                        capturesPosArr.Add(newRow.ToString() + newCol.ToString());
                    }
                }
            }
        }
        public void checkCastling()
        {
            if (this.hasMoved) return;

            bool isKingInCheck = (pieceColor == pieceColorEnum.White) ? chessLogicFuncs.inCheckWhiteKing : chessLogicFuncs.inCheckBlackKing;
            if (isKingInCheck) return;

            List<string> opponentAttacks = (pieceColor == pieceColorEnum.White)
                ? allPossibleMoveData.allCapturesMovesBlack
                : allPossibleMoveData.allCapturesMovesWhite;

            int row = (pieceColor == pieceColorEnum.White) ? 7 : 0;

            Piece rightRook = boardData.piecesBoardData[row, 7];
            if (rightRook != null && rightRook.pieceType == pieceTypeEnum.Rook && !rightRook.hasMoved)
            {
                if (boardData.piecesBoardData[row, 5] == null && boardData.piecesBoardData[row, 6] == null)
                {
                    string E = $"{row}4";
                    string F = $"{row}5";
                    string G = $"{row}6";

                    if (!opponentAttacks.Contains(E) && !opponentAttacks.Contains(F) && !opponentAttacks.Contains(G))
                    {
                        validPosArr.Add(G);
                    }
                }
            }

            Piece leftRook = boardData.piecesBoardData[row, 0];
            if (leftRook != null && leftRook.pieceType == pieceTypeEnum.Rook && !leftRook.hasMoved)
            {
                if (boardData.piecesBoardData[row, 1] == null && boardData.piecesBoardData[row, 2] == null && boardData.piecesBoardData[row, 3] == null)
                {
                    string E = $"{row}4";
                    string D = $"{row}3";
                    string C = $"{row}2";

                    if (!opponentAttacks.Contains(E) && !opponentAttacks.Contains(D) && !opponentAttacks.Contains(C))
                    {
                        validPosArr.Add(C);
                    }
                }
            }
        }
    }
}