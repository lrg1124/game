namespace Assets.Src.Card {

    public class Card {

        int mID;
        CardBigType mBigType;
        CardSmallType mSmallType;
        string mIconName;

        public Card(int id) {
            mID = id;
            CreateBigType();
            CreateSmallType();
        }

        public int ID {
            get {
                return mID;
            }
        }

        public CardBigType BigType {
            get {
                return mBigType;
            }
        }

        public CardSmallType SmallType {
            get {
                return mSmallType;
            }

        }

        public string IconName {
            get {
                return mIconName;
            }
        }

        void CreateBigType() {
            if (mID == 54) {
                mBigType = CardBigType.BIG_JOKER;
            } else if (mID == 53) {
                mBigType = CardBigType.LITTLE_JOKER;
            } else {
                mBigType = (CardBigType)(mID / 14);
            }
        }

        void CreateSmallType() {
            if (mID == 54) {
                mSmallType = CardSmallType.BIG_JOKER;
            } else if (mID == 53) {
                mSmallType = CardSmallType.LITTLE_JOKER;
            } else {
                int num = mID % 13;
                if (num <= 2) {
                    num += 13;
                }
                mSmallType = (CardSmallType)num;
            }
        }

    }
}
