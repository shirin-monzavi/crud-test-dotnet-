﻿namespace AcceptanceTests.Utility
{
    public static class RandomGenerator
    {
        public static string GenerateRandomString()
        {
            Random rand = new Random();

            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                randValue = rand.Next(0, 26);

                letter = Convert.ToChar(randValue + 65);

                str = str + letter;
            }

            return str;
        }
    }
}
