namespace SweepMethod;

public class SystemOfLinearEquations
{
    public double[,] matrix;
    public double[] freeKoefs;
    private int numOfVariable;
    public SystemOfLinearEquations(double[,] matrix)
    {
        this.matrix = matrix;
        numOfVariable = matrix.GetLength(0);
        freeKoefs = new double[numOfVariable];

    }

    public SystemOfLinearEquations(int numOfVariable)
    {
        this.numOfVariable = numOfVariable;
        matrix = new double[numOfVariable, numOfVariable];
        freeKoefs = new double[numOfVariable];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = 0;
            } 
        }
    }

    public void PrintMatrix()
    {
        Console.Clear();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }

            Console.WriteLine();
        }
        
        for (int i = 0; i < numOfVariable; i++)
        {
            Console.SetCursorPosition(30,i);
            Console.WriteLine("|" + freeKoefs[i]);
        }
    }

    public void FillTheMatrix()
    {
        int k = 3;
        int c = 0;
        Console.Write("0,0 элемент: ");
        matrix[0, 0] = Convert.ToDouble(Console.ReadLine());
        Console.Write("0,1 элемент: ");
        matrix[0, 1] = Convert.ToDouble(Console.ReadLine());
        for (int i = 1; i < matrix.GetLength(0)-1; i++)
        {
            for (int j = c; j < k; j++)
            {
                Console.Write($"{i},{j} элемент: ");
                matrix[i,j] = Convert.ToDouble(Console.ReadLine());
            }

            k++;
            c++;
        }

        Console.Write($"{numOfVariable-1},{numOfVariable-2} элемент: ");
        matrix[numOfVariable-1, numOfVariable-2] = Convert.ToDouble(Console.ReadLine());
        
        Console.Write($"{numOfVariable-1},{numOfVariable-1} элемент: ");
        matrix[numOfVariable-1, numOfVariable-1] = Convert.ToDouble(Console.ReadLine());
    }

    public void FillTheFreeKoefs()
    {
        for (int i = 0; i < freeKoefs.Length; i++)
        {
            Console.Write($"{i} коэффициент: ");
            freeKoefs[i] = Convert.ToDouble(Console.ReadLine());
        }
    }
}