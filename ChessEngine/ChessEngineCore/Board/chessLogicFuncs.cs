using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ChessEngine.ChessEngineCore.Piece;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class chessLogicFuncs
    {
        public static bool inCheckWhiteKing = false;
        public static bool inCheckBlackKing = false;

        public static void isKingInCheck()
        {
            if (allPossibleMoveData.allCapturesMovesWhite.Contains(boardData.blackKingIndexX.ToString() + boardData.blackKingIndexY.ToString()))
            {
                inCheckBlackKing = true;
            }
            else
            {
                inCheckBlackKing = false;
            }

            if (allPossibleMoveData.allCapturesMovesBlack.Contains(boardData.whiteKingIndexX.ToString() + boardData.whiteKingIndexY.ToString()))
            {
                inCheckWhiteKing = true;
            }
            else
            {
                inCheckWhiteKing = false;
            }
        }

        public static void kingInCheckMoves(Piece piece)
        {
            controlValids(piece);
        }

        public static void controlValids(Piece piece)
        {
            piece.allPossibleMoves();
            List<string> currentValidMoves = new List<string>(piece.validPosArr);
            List<string> currentCaptureMoves = new List<string>(piece.capturesPosArr);

            List<string> canMoveArr = new List<string>();
            List<string> canCaptureArr = new List<string>();

            string originalPieceId = piece.pieceId;
            int piecePosX = Convert.ToInt32(originalPieceId[0].ToString());
            int piecePosY = Convert.ToInt32(originalPieceId[1].ToString());
            for (int i = 0; i < currentValidMoves.Count; i++)
            {
                Piece[,] tempBoard = (Piece[,])boardData.piecesBoardData.Clone();
                string validPosXY = currentValidMoves[i];
                int validPosX = Convert.ToInt32(validPosXY[0].ToString());
                int validPosY = Convert.ToInt32(validPosXY[1].ToString());

                tempBoard[validPosX, validPosY] = piece;
                piece.pieceId = validPosXY;
                tempBoard[piecePosX, piecePosY] = null;

                int checkKingX = (piece.pieceColor == pieceColorEnum.White) ? boardData.whiteKingIndexX : boardData.blackKingIndexX;
                int checkKingY = (piece.pieceColor == pieceColorEnum.White) ? boardData.whiteKingIndexY : boardData.blackKingIndexY;

                if (piece.pieceType == pieceTypeEnum.King)
                {
                    checkKingX = validPosX;
                    checkKingY = validPosY;
                }

                if (allPossibleMoveData.controlNewPosCheck(tempBoard, piece.pieceColor, checkKingX, checkKingY))
                {
                    canMoveArr.Add(validPosXY);
                }
                piece.pieceId = originalPieceId;
            }

            for (int i = 0; i < currentCaptureMoves.Count; i++)
            {
                Piece[,] tempBoard = (Piece[,])boardData.piecesBoardData.Clone();
                string validPosXY = currentCaptureMoves[i];
                int validPosX = Convert.ToInt32(validPosXY[0].ToString());
                int validPosY = Convert.ToInt32(validPosXY[1].ToString());

                tempBoard[validPosX, validPosY] = piece;
                piece.pieceId = validPosXY;
                tempBoard[piecePosX, piecePosY] = null;

                int checkKingX = (piece.pieceColor == pieceColorEnum.White) ? boardData.whiteKingIndexX : boardData.blackKingIndexX;
                int checkKingY = (piece.pieceColor == pieceColorEnum.White) ? boardData.whiteKingIndexY : boardData.blackKingIndexY;

                if (piece.pieceType == pieceTypeEnum.King)
                {
                    checkKingX = validPosX;
                    checkKingY = validPosY;
                }

                if (allPossibleMoveData.controlNewPosCheck(tempBoard, piece.pieceColor, checkKingX, checkKingY))
                {
                    canCaptureArr.Add(validPosXY);
                }
                piece.pieceId = originalPieceId;
            }

            piece.validPosArr = canMoveArr;
            piece.capturesPosArr = canCaptureArr;
        }

        public static bool sameColorBlockLogic(int posX, int posY)
        {
            if (boardData.piecesBoardData[posX, posY] != null)
            {
                pieceColorEnum moveLocationColor = boardData.piecesBoardData[posX, posY].pieceColor;
                if (moveLocationColor != boardData.turnColor)
                {
                    return true;
                }
            }
            return false;
        }
        public static void checkGameOver()
        {
            int totalLegalMoves = 0;
            Piece.pieceColorEnum playerColor = boardData.turnColor;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = boardData.piecesBoardData[i, j];
                    if (piece != null && piece.pieceColor == playerColor)
                    {
                        controlValids(piece);
                        totalLegalMoves += piece.validPosArr.Count;
                    }
                }
            }

            if (totalLegalMoves == 0)
            {
                bool isKingInCheck = (playerColor == Piece.pieceColorEnum.White) ? inCheckWhiteKing : inCheckBlackKing;

                if (isKingInCheck)
                {
                    string winner = (playerColor == Piece.pieceColorEnum.White) ? "BLACK" : "WHITE";
                    MessageBox.Show($"CHECKMATE! {winner} Won.", "Gameover");
                }
                else
                {
                    MessageBox.Show("STALEMATE! Draw.", "Gameover");
                }
            }
        }
    }
}