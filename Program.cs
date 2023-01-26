internal class Program
{
    private static void Main(string[] args)
    {
        int[] cards = new int[52];
        int[] player1 = new int[26];
        int[] player2 = new int[26];
        int player1Points = 0;
        int player2Points = 0;
        int k = 0;
        int i;
        int j;
        int resp;
        RandomNumbers.nrandom();

        Console.Write("\n\n\t Random numbers from 1 to 52 \n\n\t");
        for (i = 0; i < 52; i++)
        {
            cards[i] = 1 + RandomNumbers.NextNumber() % 52;
        }
        PrintCards(cards, 52);

        k = 1;
        for (j = 0; j < 51; j++)
        {
            for (i = j + 1; i < 52; i++)
            {
                if (cards[j] == cards[i])
                {
                    cards[i] = cards[i] + 1;
                    if (cards[i] > 52)
                    {
                        cards[i] = cards[i] - 52;
                    }
                    i = j;
                    j = 0;

                    k++;
                }
            }
        }
        k = 0;
        for (k = 0; k < 52; k++)
        {
            while (cards[k] > 10)
            {
                cards[k] = cards[k] - 10;
            }
        }
        k = 0;
        for (i = 0; i < 52; i++)
        {
            if (i % 2 == 0)
            {
                player1[i / 2] = cards[i];
            }
            else
            {
                player2[(i - 1) / 2] = cards[i];
            }
        }

        Console.Write("\n\n\t Player 1 cards: \n\n\t");
        PrintCards(player1, 26);

        Console.Write("\n\n\t Player 2 cards: \n\n\t");
        PrintCards(player2, 26);

        Console.Write("\n\n\t Players points: ");

        for (i = 0; i < 26; i++)
        {
            if (player1[i] - player2[i] > 0)
            {
                player1Points++;
            }
            else if (player1[i] - player2[i] < 0)
            {
                player2Points++;
            }
            else if (player1[i] - player2[i] == 0)
            {
                k = 1;
                do
                {
                    if (player1[i + k] - player2[i + k] > 0)
                    {
                        player1Points = player1Points + 1 + k;
                    }
                    else if (player1[i + k] - player2[i + k] < 0)
                    {
                        player2Points = player2Points + 1 + k;
                    }
                    k++;
                    if (i + k > 26)
                    {
                        break;
                    }
                } while (player1[i + k] - player2[i +k] == 0);
                i = i + k - 1;
            }
        }
        Console.Write("\n\n\t Player 1 points: {0,2:D}; Cards: {1,2:D}", player1Points, 2 * player1Points);
        Console.Write("\n\n\t Player 2 points: {0,2:D}; Cards: {1,2:D}", player2Points, 2 * player2Points);


        if (player1Points != player2Points)
        {
            Console.Write("\n\t The winner is: ");
            if (player1Points > player2Points)
            {
                Console.Write(" Player 1");
            }
            else
            {
                Console.Write(" Player 2");
            }
        }
        else
        {
            Console.Write("\n\t TIE!");
        }
        Console.Write("\n\n\n\t");


        int PrintCards(int[] cards, int tam)
        {
            int i;
            int j;
            int k = 0;
            for (i = 1; i <= 4; i++)
            {
                for (j = 1; j <= tam / 4; j++)
                {
                    Console.Write("{0,2:D}", cards[k]);
                    if (k < tam - 1)
                    {
                        Console.Write(", ");
                    }
                    k++;
                }
                Console.Write("\n\t");
            }
            return tam;
        }
    }
}