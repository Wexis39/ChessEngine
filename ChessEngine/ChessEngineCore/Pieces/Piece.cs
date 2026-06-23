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
            set { _pieceId = value; setDefaultPos(); }
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
                    _fullImagePath = null;
                }
                return _fullImagePath;
            }
        }
        //---Position---
        private int _posRow;
        public int posRow
        {
            get { return Convert.ToInt32(pieceId[0].ToString()); }
            set { _posRow = Convert.ToInt32(value); }
        }
        private int _posCol;
        public int posCol
        {
            get { return Convert.ToInt32(pieceId[1].ToString()); }
            set { _posCol = Convert.ToInt32(value); }
        }
        private string[] _validPosArr;
        public string[] validPosArr
        {
            get { return _validPosArr; }
            set { _validPosArr = value; }
        }
        public void setDefaultPos()
        {
            posRow = Convert.ToInt32(pieceId[0].ToString());
            posCol = Convert.ToInt32(pieceId[1].ToString());
        }
        public virtual void GetValidMoves() { }
        public virtual void GetCaptures() { }
    }
}
