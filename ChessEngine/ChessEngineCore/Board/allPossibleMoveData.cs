using System;
using System.Collections.Generic;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class allPossibleMoveData
    {
        public static List<string> allValidMovesWhite;
        public static List<string> allCapturesMovesWhite;
        public static List<string> allValidMovesBlack;
        public static List<string> allCapturesMovesBlack;
        public static Piece[,] tempBoardData;

        public static void calculatePossibeMoves()
        {
            allValidMovesWhite = new List<string>();
            allCapturesMovesWhite = new List<string>();
            allValidMovesBlack = new List<string>();
            allCapturesMovesBlack = new List<string>();

            boardData.enPassantCapturesArr = new List<string>();

            tempBoardData = (Piece[,])boardData.piecesBoardData.Clone();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tempBoardData[i, j] != null)
                    {
                        if (tempBoardData[i, j].pieceColor == Piece.pieceColorEnum.White)
                        {
                            tempBoardData[i, j].allPossibleMoves();
                            allValidMovesWhite.AddRange(tempBoardData[i, j].validPosArr);
                            allCapturesMovesWhite.AddRange(tempBoardData[i, j].capturesPosArr);
                        }
                        else if (tempBoardData[i, j].pieceColor == Piece.pieceColorEnum.Black)
                        {
                            tempBoardData[i, j].allPossibleMoves();
                            allValidMovesBlack.AddRange(tempBoardData[i, j].validPosArr);
                            allCapturesMovesBlack.AddRange(tempBoardData[i, j].capturesPosArr);
                        }
                    }
                }
            }
        }

        public static List<string> allCapturesForCheck;

        public static bool controlNewPosCheck(Piece[,] tempBoard, Piece.pieceColorEnum color, int kingX, int kingY)
        {
            Piece.pieceColorEnum controlColor = (color == Piece.pieceColorEnum.Black) ? Piece.pieceColorEnum.White : Piece.pieceColorEnum.Black;
            allCapturesForCheck = new List<string>();
            Piece[,] originalBoard = boardData.piecesBoardData;
            boardData.piecesBoardData = tempBoard;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tempBoard[i, j] != null && tempBoard[i, j].pieceColor == controlColor)
                    {
                        tempBoard[i, j].allPossibleMoves();
                        allCapturesForCheck.AddRange(tempBoard[i, j].capturesPosArr);
                    }
                }
            }
            boardData.piecesBoardData = originalBoard;

            string kingTargetPos = kingX.ToString() + kingY.ToString();
            if (allCapturesForCheck.Contains(kingTargetPos))
            {
                return false;
            }

            return true;
        }
    }
}