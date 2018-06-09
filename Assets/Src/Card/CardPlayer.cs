using System.Collections.Generic;

namespace Assets.Src.Card {

    public class CardPlayer {

        List<Card> mCards;

        public CardPlayer() {

        }

        /// <summary>
        /// 出牌
        /// </summary>
        /// <param name="otherCards"></param>
        public void Deal(List<Card> otherCards) {
        }

        /// <summary>
        /// 是否为单张
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsSolo(List<Card> cards) {
            if (cards.Count == 1) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为对子
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsPair(List<Card> cards) {
            if (cards.Count == 2 && cards[0].SmallType == cards[1].SmallType) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为3张
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsTrio(List<Card> cards) {
            if (cards.Count == 3 && cards[0].SmallType == cards[1].SmallType && cards[0].SmallType == cards[2].SmallType) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为3带1
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsTrioWithSolo(List<Card> cards) {
            if (cards.Count == 4) {
                cards.Sort(Comparor);
                if (cards[0].SmallType == cards[1].SmallType && cards[0].SmallType == cards[2].SmallType && cards[0].SmallType != cards[3].SmallType) {
                    return true;
                } else if (cards[0].SmallType != cards[1].SmallType && cards[1].SmallType == cards[2].SmallType && cards[1].SmallType == cards[3].SmallType) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为顺子
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsChain(List<Card> cards) {
            if (cards.Count >= 5 && cards.Count < 12) {
                cards.Sort(Comparor);
                for (int i = 0; i < cards.Count - 1; i++) {
                    var curr = (int)cards[i].SmallType;
                    var next = (int)cards[i + 1].SmallType;
                    if (curr == (int)CardSmallType.BIG_JOKER || curr == (int)CardSmallType.LITTLE_JOKER
                        || curr == (int)CardSmallType.TWO || curr != next - 1) {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为4带2
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsFourWithTwoSolo(List<Card> cards) {
            if (cards.Count == 4 && cards[0].SmallType == cards[1].SmallType && cards[0].SmallType == cards[2].SmallType
                && cards[0].SmallType == cards[3].SmallType) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为炸弹
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsBomb(List<Card> cards) {
            if (cards.Count == 4 && cards[0].SmallType == cards[1].SmallType && cards[0].SmallType == cards[2].SmallType
                && cards[0].SmallType == cards[3].SmallType) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否为王炸
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsNuke(List<Card> cards) {
            if (cards.Count == 2 && cards[0].ID >= 53 && cards[1].ID >= 53) {
                return true;
            }
            return false;
        }

        int Comparor(Card a, Card b) {
            return a.ID - b.ID;
        }

    }
}
