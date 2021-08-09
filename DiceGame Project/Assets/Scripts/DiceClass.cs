using UnityEngine;

// Generic class that the three buttons derive from
public class DiceButton
{
    public int luckiness;

    public DiceButton(int luckFactor = 0)
    {
        luckiness = luckFactor;
    }

    // Rolls a number, 1-100. If the number rolled is <= the button's luck, the player wins.
    public bool RTD()
    {
        return Random.Range(1, 100) <= this.luckiness;
    }

    // This function returns the bet of a button the player didn't pick.
    public virtual int ReturnAnythingBut(int[] betValues)
    {
        return betValues[2];
    }

    // Generic version can be used if the parent class is ever used.
    public int ReturnAnythingBut(int betAvoid, int[] betValues)
    {
        // Create a generic int variable, attempt to set it.
        //  If it is the same as the int passed into the function, try again.
        int bet;
        do
        {
            bet = Random.Range(0, 2);
        } while (bet == betAvoid);
        return betValues[bet];
    }
}

// Wins 10% of the time
public class BadButton : DiceButton
{
    public BadButton()
    {
        luckiness = 10;
    }

    // Bad Button always says that the random button won
    public override int ReturnAnythingBut(int[] betValues)
    {
        return betValues[1];
    }
}

// Wins 50% of the time
public class RandButton : DiceButton
{
    public RandButton()
    {
        luckiness = 50;
    }

    // Random Button always says the good button won
    public override int ReturnAnythingBut(int[] betValues)
    {
        return betValues[2];
    }
}

// Wins 80% of the time
public class GoodButton : DiceButton
{
    public GoodButton()
    {
        luckiness = 80;
    }

    // Good button always says the bad button won
    public override int ReturnAnythingBut(int[] betValues)
    {
        return betValues[0];
    }
}
