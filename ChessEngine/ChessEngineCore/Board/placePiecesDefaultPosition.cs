using ChessEngine.ChessEngineCore.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessEngine.ChessEngineCore.Piece;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class placePiecesDefaultPosition
    {
        public static void _placePiecesDefaultPosition()
        {
            createBlackPawns();
            createWhitePawns();
            createBlackRooks();
            createWhiteRooks();
            createBlackQueen();
            createWhiteQueen();
            createBlackKing();
            createWhiteKing();
            createBlackKnight();
            createWhiteKnight();
            createBlackBishop();
            createWhiteBishop();
        }
        public static void createBlackPawns()
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn pawn = new Pawn(pieceColorEnum.Black);
                pawn.pieceId = $"1{i}";
                boardData.piecesBoardData[1, i] = pawn;
            }
        }
        public static void createWhitePawns()
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn pawn = new Pawn(pieceColorEnum.White);
                pawn.pieceId = $"6{i}";
                boardData.piecesBoardData[6, i] = pawn;
            }
        }
        public static void createBlackRooks()
        {
            Rook rook1 = new Rook(pieceColorEnum.Black);
            Rook rook2 = new Rook(pieceColorEnum.Black);
            rook1.pieceId = "00";
            rook2.pieceId = "07";
            boardData.piecesBoardData[0, 0] = rook1;
            boardData.piecesBoardData[0, 7] = rook2;
        }
        public static void createWhiteRooks()
        {
            Rook rook1 = new Rook(pieceColorEnum.White);
            Rook rook2 = new Rook(pieceColorEnum.White);
            rook1.pieceId = "70";
            rook2.pieceId = "77";
            boardData.piecesBoardData[7, 0] = rook1;
            boardData.piecesBoardData[7, 7] = rook2;
        }
        public static void createBlackQueen()
        {
            Queen queen = new Queen(pieceColorEnum.Black);
            queen.pieceId = "03";
            boardData.piecesBoardData[0, 3] = queen;
        }
        public static void createWhiteQueen()
        {
            Queen queen = new Queen(pieceColorEnum.White);
            queen.pieceId = "73";
            boardData.piecesBoardData[7, 3] = queen;
        }
        public static void createBlackKing()
        {
            King king = new King(pieceColorEnum.Black);
            king.pieceId = "04";
            boardData.blackKingIndexX=0;
            boardData.blackKingIndexY=4;
            boardData.piecesBoardData[0, 4] = king;
        }
        public static void createWhiteKing()
        {
            King king = new King(pieceColorEnum.White);
            king.pieceId = "74";
            boardData.whiteKingIndexX=7;
            boardData.whiteKingIndexY=4;
            boardData.piecesBoardData[7, 4] = king;
        }
        public static void createBlackKnight()
        {
            Knight knight1 = new Knight(pieceColorEnum.Black);
            knight1.pieceId = "01";
            boardData.piecesBoardData[0, 1] = knight1;
            Knight knight2 = new Knight(pieceColorEnum.Black);
            knight2.pieceId = "06";
            boardData.piecesBoardData[0, 6] = knight2;
        }
        public static void createWhiteKnight()
        {
            Knight knight1 = new Knight(pieceColorEnum.White);
            knight1.pieceId = "71";
            boardData.piecesBoardData[7, 1] = knight1;
            Knight knight2 = new Knight(pieceColorEnum.White);
            knight2.pieceId = "76";
            boardData.piecesBoardData[7, 6] = knight2;
        }
        public static void createBlackBishop()
        {
            Bishop bishop1 = new Bishop(pieceColorEnum.Black);
            bishop1.pieceId = "02";
            boardData.piecesBoardData[0, 2] = bishop1;
            Bishop bishop2 = new Bishop(pieceColorEnum.Black);
            bishop2.pieceId = "05";
            boardData.piecesBoardData[0, 5] = bishop2;
        }
        public static void createWhiteBishop()
        {
            Bishop bishop1 = new Bishop(pieceColorEnum.White);
            bishop1.pieceId = "72";
            boardData.piecesBoardData[7, 2] = bishop1;
            Bishop bishop2 = new Bishop(pieceColorEnum.White);
            bishop2.pieceId = "75";
            boardData.piecesBoardData[7, 5] = bishop2;
        }
    }
}
