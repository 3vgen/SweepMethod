namespace SweepMethod;

public class Sweep
{
    private double[] V;
    private double[] U;
    private double[,] matrix;
    private double[] freeKoefs;
    private double[] roots;
    private int len;
    

    public Sweep(double[,] matrix, double[] freeKoefs)
    {
        this.matrix = matrix;
        this.freeKoefs = freeKoefs;
        V = new double[freeKoefs.Length];
        U = new double[freeKoefs.Length];
        roots = new double[freeKoefs.Length];
        len = V.Length;
    }

    public void SearchSweepKoefs()
    {
        V[0] = matrix[0, 1] / -matrix[0, 0];
        U[0] = -freeKoefs[0] / -matrix[0, 0];
        // V[0] = 0;
        // U[0] = 0;
        for (int i = 1; i < V.Length-1; i++)
        {
            V[i] = matrix[i, i + 1] / (-matrix[i, i] - matrix[i, i - 1] * V[i - 1]);
            U[i] = (matrix[i, i - 1] * U[i - 1] - freeKoefs[i]) / (-matrix[i, i] - matrix[i, i - 1] * V[i - 1]);
        }

        V[len - 1] = 0;
        U[len - 1] = (matrix[len - 1, len - 2] * U[len - 2] - freeKoefs[len - 1]) /
                     (-matrix[len - 1, len - 1] - matrix[len - 1, len - 2] * V[len - 2]);
    }

    public void SearchRoots()
    {
        roots[len - 1] = U[len - 1];
        for (int i = len -1; i >= 1; i--)
        {
            roots[i - 1] = V[i - 1] * roots[i] + U[i - 1];
        }
    }

    public void ShowRoots()
    {
        Console.WriteLine("Корни");
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine(roots[i]);
        }
    }

    public bool isCorrectMatrix()
    {
        return true;
    }
    public void CheckAnswer()
    {
        Console.WriteLine("Ответы");
        Console.WriteLine(matrix[0,0]*roots[0] + matrix[0,1]*roots[1] + " == " + freeKoefs[0]);
        Console.WriteLine(matrix[1,0]*roots[0] +  matrix[1,1]*roots[1] + matrix[1,2]*roots[2]+ " == " + freeKoefs[1]);
        Console.WriteLine(matrix[2,1]*roots[1] +  matrix[2,2]*roots[2] + matrix[2,3]*roots[3]+ " == " + freeKoefs[2]);
        Console.WriteLine(matrix[3,2]*roots[2]+matrix[3,3]*roots[3]+ " == " + freeKoefs[3]);
    }
    
}