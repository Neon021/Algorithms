namespace Main
{
    public class Program
    {
        public static void Main()
        {
            AuctionSystem auctionSystem = new(); // Initialize the Auction system
            auctionSystem.AddBid(1, 7, 5); // User 1 bids 5 on item 7
            auctionSystem.AddBid(2, 7, 6); // User 2 bids 6 on item 7
            auctionSystem.GetHighestBidder(7); // return 2 as User 2 has the highest bid
            auctionSystem.UpdateBid(1, 7, 8); // User 1 updates bid to 8 on item 7
            auctionSystem.GetHighestBidder(7); // return 1 as User 1 now has the highest bid
            auctionSystem.RemoveBid(2, 7); // Remove User 2's bid on item 7
            auctionSystem.GetHighestBidder(7); // return 1 as User 1 is the current highest bidder
            auctionSystem.GetHighestBidder(3); // return -1 as no bids exist for item 3
        }
        public class AuctionSystem
        {
            private readonly Dictionary<(int userId, int itemId), int> Users = new(); //  will yield bidAmount

            //TKey is itemId
            //TValue is a sortedDictionary with descending bidAmount
            //It's TValue is also a SortedSet of userId because. If multiple users have the same highest bidAmount, we are going to return the user with the highest userId.
            private readonly Dictionary<int, SortedDictionary<int, SortedSet<int>>> Bids = new(); // itemId -> [ bid: [ userId ]]

            public AuctionSystem()
            {

            }

            public void AddBid(int userId, int itemId, int bidAmount)
            {
                if (!Users.ContainsKey((userId, itemId)))
                    Users.Add((userId, itemId), bidAmount);
                else
                    Users[(userId, itemId)] = bidAmount;


                Bids.TryGetValue(itemId, out SortedDictionary<int, SortedSet<int>>? bids);
                if (bids == null)
                {
                    bids = new SortedDictionary<int, SortedSet<int>>()
                    {
                        { bidAmount, new SortedSet<int>() { userId } }
                    };
                    Bids[itemId] = bids;
                }
                else
                {
                    bids.TryGetValue(bidAmount, out SortedSet<int>? users);
                    if (users == null)
                    {
                        users = new SortedSet<int> { userId };
                        bids[bidAmount] = users;
                    }
                    else
                    {
                        users.Add(userId);
                        bids[bidAmount] = users;
                    }
                }
            }

            public void UpdateBid(int userId, int itemId, int newAmount)
            {
                //guaranteed that bid of the userId for itemId exists
            }

            public void RemoveBid(int userId, int itemId)
            {
                //guaranteed that bid of the userId for itemId exists
            }

            public int GetHighestBidder(int itemId)
            {
                //If multiple users have the same highest bidAmount, return the user with the highest userId
            }
        }

        public static int VowelConsonantScore(string s)
        {
            //s consists english letters, digits and spaces
            //Let v be the number of vowels(sesli harf) in s and c be the number of consonants(sessiz harf) in s.
            //A vowel is one of the letters 'a', 'e', 'i', 'o', or 'u', while any other letter in the English alphabet is considered a consonant.
            //The score of the string s is defined as follows:
            //
            //    If c > 0, the score = floor(v / c) where floor denotes rounding down to the nearest integer.
            //    Otherwise, the score = 0.
            //
            //Return an integer denoting the score of the string.

            decimal numberOfConsonants = 0;
            decimal numberOfVowels = 0;
            foreach (char cha in s)
            {
                if (cha == 'a' || cha == 'e' || cha == 'i' || cha == 'o' || cha == 'u')
                    numberOfVowels++;
                else if (char.IsLetter(cha))
                    numberOfConsonants++;
            }

            return numberOfConsonants > 0 ? (int)Math.Floor(numberOfVowels / numberOfConsonants) : 0;
        }
    }
}