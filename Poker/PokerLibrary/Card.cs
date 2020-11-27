﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class Card
    {

        public enum SUIT
        {
            HEARTS, SPADES, DIAMONDS, CLUBS
        }

        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }

        

    }
}
