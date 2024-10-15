using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CreditCard> list = new List<CreditCard>();
            while (true)
            {
                Console.WriteLine("1-add,2-update,3-search,4-delete");
                Console.WriteLine("enter choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter cardholder name");
                        var Name = Console.ReadLine();
                        Console.WriteLine("Enter card number");
                        var CardNumber = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter expiry (MM/YY)");
                        var expiry = Console.ReadLine();

                        var details = new CreditCard
                        {
                            CardHolderName = Name,
                            CardNumber = CardNumber,
                            ExpiryMonth = byte.Parse(expiry.Split('/')[0]),
                            ExpiryYear = byte.Parse(expiry.Split('/')[1])
                        };
                        list.Add(details);
                        Console.WriteLine(details);
                        break;

                    case 2:
                        CreditCard updatecard = null;
                        Console.WriteLine("enter card number for updation");
                        var cardnumber = long.Parse(Console.ReadLine());

                        foreach (var card in list)
                        {
                            if (card.CardNumber == cardnumber)
                            {
                                updatecard = card;
                                break;
                            }
                        }

                        if (updatecard != null)
                        {
                            Console.WriteLine("Enter new card number");
                            var newcardnumber = long.Parse(Console.ReadLine());
                            updatecard.CardNumber = newcardnumber;
                            Console.WriteLine("card updated successfully");
                        }
                        Console.WriteLine("updated elements are " + updatecard);
                        break;

                    case 3:
                        Console.WriteLine("enter card number for searching");
                        var searchnum = long.Parse(Console.ReadLine());

                        CreditCard searchnumber = null;
                        foreach (var card in list)
                        {
                            if (card.CardNumber == searchnum)
                            {
                                searchnumber = card;
                                break;
                            }
                        }
                        Console.WriteLine("Elements are " + searchnumber);
                        break;

                    case 4:
                        Console.WriteLine("enter card number");
                        var CardNumbernForDeletion= long.Parse(Console.ReadLine());
                        CreditCard delnumber = null;
                        foreach (var card in list)
                        {
                            if (card.CardNumber == CardNumbernForDeletion)
                            {
                                delnumber = card;
                                break;
                            }
                        }
                        if(delnumber != null)
                        {
                            list.Remove(delnumber);
                            Console.WriteLine("successfully deleted");
                        }
                         break;
                }
            }
        }
    }
}
