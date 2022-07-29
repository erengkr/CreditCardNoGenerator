
using CreditCardNoGenerator;

List<string> binList = new List<string>();
binList.Add("43445715");
binList.Add("49125416");
binList.Add("51539412");
binList.Add("57091627");

List<List<string>> cardList = CardNoGenerator.GenerateCardNumbers(binList, 16, 5);
foreach (List<string> list in cardList)
{
    foreach (var cardNo in list)
        Console.WriteLine(CardNoGenerator.FormatCardNo(cardNo));
    Console.WriteLine();
}