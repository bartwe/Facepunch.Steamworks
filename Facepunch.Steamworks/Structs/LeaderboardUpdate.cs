﻿namespace Steamworks.Data {
    public struct LeaderboardUpdate {
        public int Score;
        public bool Changed;
        public int NewGlobalRank;
        public int OldGlobalRank;

        public int RankChange {
            get { return NewGlobalRank - OldGlobalRank; }
        }

        internal static LeaderboardUpdate From(LeaderboardScoreUploaded_t e) {
            return new() {
                Score = e.Score, Changed = e.ScoreChanged == 1, NewGlobalRank = e.GlobalRankNew, OldGlobalRank = e.GlobalRankPrevious,
            };
        }
    }
}
