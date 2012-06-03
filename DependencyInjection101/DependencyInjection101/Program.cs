﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection101
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditCard mcard = new Mastercard();
            ICreditCard vcard = new VisaCard();
            Shopper shopper = new Shopper(mcard);
            shopper.Charge();
            Console.Read();
        }
    }

    public class Shopper
    {
        private ICreditCard card;
        public Shopper(ICreditCard _card)
        {
            card = _card;
        }

        public void Charge()
        {
            card.chargeApplied();
        }
    }

    public interface ICreditCard
    {
        void chargeApplied();

    }

    public class VisaCard : ICreditCard
    {
        public void chargeApplied()
        {
            Console.WriteLine("Visa Card: Charges are applied");
        }
    }

    public class Mastercard : ICreditCard
    {
        public void chargeApplied()
        {
            Console.WriteLine("Master Card: Charges are applied");
        }
    }
}
