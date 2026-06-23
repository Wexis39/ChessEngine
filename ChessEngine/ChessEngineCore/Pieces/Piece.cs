using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore
{
    public class Piece
    {
        public Piece(pieceColorEnum pieceColorParam)
        {
            _pieceColor = pieceColorParam;
        }
        public enum pieceColorEnum
        {
            Black,
            White
        }
        public enum pieceTypeEnum
        {
            Bishop,
            King,
            Knight,
            Pawn,
            Queen,
            Rook
        }
        private pieceColorEnum _pieceColor;
        private pieceTypeEnum _pieceType;
        private string _pieceId;
        private string _fullImagePath;
        public string pieceId
        {
            get { return _pieceId; }
            set { _pieceId = value; }
        }
        public pieceColorEnum pieceColor
        {
            get{ return _pieceColor; }
            set{ _pieceColor = value; }
        }
        public pieceTypeEnum pieceType
        {
            get{ return _pieceType; }
            set{ _pieceType = value; }
        }
        public string fullImagePath
        {
            get
            {
                if (_pieceColor == pieceColorEnum.Black)
                {
                    _fullImagePath = $"black-{_pieceType.ToString().ToLower()}";
                }
                else if (_pieceColor == pieceColorEnum.White)
                {
                    _fullImagePath = $"white-{_pieceType.ToString().ToLower()}";
                }
                else
                {
                    _fullImagePath = "notFound";
                }
                return _fullImagePath;
            }
        }
        public void GetValidMoves() { }
        public void GetCaptures() { }
    }
}
