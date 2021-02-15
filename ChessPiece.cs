using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    class ChessPiece
    {
        public enum Type
        {
            PAWN,
            CASTLE,
            BISHOP,
            ROOK,
            QUEEN,
            KING
        }

        protected ChessBoard board;

        EChessSide side;
        int row;
        int col;
        Type type;
        
        public ChessPiece(ChessBoard board, EChessSide side, Type type, int row, int col)
        {
            this.board = board;
            this.side = side;
            this.type = type;
            this.row = row;
            this.col = col;
        }

        public virtual bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetCol()
        {
            return col;
        }

        public Type GetPieceType()
        {
            return type;
        }

        public EChessSide GetSide()
        {
            return side;
        }

        public void MoveTo(int row, int col)
        {
            board.SetBoardPiece(this.row, this.col, null);
            this.row = row;
            this.col = col;
            board.SetBoardPiece(this.row, this.col, this);
        }

    }

    class ChessPiecePawn : ChessPiece
    {
        public ChessPiecePawn(ChessBoard board, EChessSide side, int row, int col) : 
            base(board, side, Type.PAWN, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {

            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;

            if(GetSide() == EChessSide.WHITE)
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() + 1 == targetRow)
                        return true;
                }
            }
            else
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() - 1 == targetRow)
                        return true;
                }
            }
            
            return false;
        }
    }

    class ChessPieceQUEEN : ChessPiece
    {
        public ChessPieceQUEEN(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.QUEEN, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {

            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;

            if (GetSide() == EChessSide.WHITE)
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() + 8 == targetRow)
                        return true;
                }
            }
            else
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() - 8 == targetRow)
                        return true;
                }
            }

            return false;
        }
    }
}
