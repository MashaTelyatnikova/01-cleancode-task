using System.Linq;

namespace CleanCode
{
	public class Chess
	{
		private readonly Board board;

		public Chess(Board board)
		{
		    this.board = board;
		}

		public string GetWhiteStatus() {
			var bad = CheckForWhite();
			var ok =  false;
			foreach (var loc1 in board.Figures(Cell.White))
			{
				foreach (var loc2 in board.Get(loc1).Figure.Moves(loc1, board)){
				    var oldDest = board.PerformMove(loc1, loc2);
				
				    if (!CheckForWhite( ))
					    ok = true;
				    board.PerformUndoMove(loc1, loc2, oldDest);
				}
            }

			if (bad)
				return ok ? "check" : "mate";
				return ok ? "ok" : "stalemate";
		}

		private bool CheckForWhite()
		{
			
		    return board.Figures(Cell.Black)
		                .Any(loc => board.Get(loc).Figure.Moves(loc, board).Select(board.Get).Any(i => !i.IsWhiteKing));
			
		}
	}
}