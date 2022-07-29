using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardNoGenerator
{
    internal class CardNoGenerator
    {
        public static int GetCheckSumDigit(string cardNo, int cardNoLen)
        {
            int checkDigit = 0;
            int cardNoLength = 0;
            if (cardNo.Length >= cardNoLen)
                cardNoLength = cardNoLen - 1;
            else
                cardNoLength = cardNo.Length;
            bool bDouble = true;
            int digitsSum = 0;
            for (int i = cardNo.Length - 1; i >= 0; i--)
            {
                int iDigit = Convert.ToInt32(cardNo.Substring(i, 1));

                if (bDouble)
                {
                    iDigit = iDigit * 2;
                    digitsSum += iDigit / 10 + iDigit % 10;
                    bDouble = false;
                }
                else
                {
                    digitsSum += iDigit;
                    bDouble = true;
                }
                checkDigit = digitsSum % 10;
            }
            return checkDigit == 0 ? 0 : 10 - checkDigit;
        }
        public static List<List<string>> GenerateCardNumbers(List<string> binList, int cardNoLen, int numOfCardsPerBin)
        {
            List<List<string>> cardList = new List<List<string>>();
            foreach (var bin in binList)
            {
                int totalCards = 0;
                List<string> cardListPerBin = new List<string>();
                while (totalCards < numOfCardsPerBin)
                {
                    int randValue = new Random().Next(9999999);
                    string newCardNo = bin + randValue.ToString().PadLeft(7, '0') + GetCheckSumDigit(bin + randValue.ToString().PadLeft(7, '0'), cardNoLen);
                    cardListPerBin.Add(newCardNo);
                    totalCards++;
                }
                cardList.Add(cardListPerBin);
            }
            return cardList;
        }
        public static string FormatCardNo(string cardNo)
        {
            return cardNo.Substring(0, 4) + " " +
                cardNo.Substring(4, 4) + " " +
                cardNo.Substring(8, 4) + " " +
                cardNo.Substring(12, 4);
        }
    }
}
