 

using SweepMethod;

double[,] mat = new double[4, 4]
{
    { 5, -1, 0, 0 }, 
    { 2, 4.6, -1, 0 }, 
    { 0, 2, 3.6, -0.8},
    { 0, 0, 3, 4.4}
};
double[] freeKoefs = new[]
{
    2, 3.3, 2.6, 7.2
};

// SystemOfLinearEquations ur = new SystemOfLinearEquations(4);
// ur.FillTheMatrix();
// ur.FillTheFreeKoefs();
// ur.PrintMatrix();
Sweep sw = new Sweep(mat,freeKoefs);
sw.SearchSweepKoefs();
sw.SearchRoots();
sw.ShowRoots();
sw.CheckAnswer();