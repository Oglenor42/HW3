public class Diag {

  private double[] x;

  public Diag(int n) { x = new double[n];}
  
  public double Get(int i, int j) => Value(i, j);

  public void Set(int i, int j, double e) => SetValue(i, j, e);

  public static Diag Add(Diag a, Diag b) { return a + b; }

  public static Diag Multiply(Diag a, Diag b) { return a * b; }

  public static Diag operator +(Diag a, Diag b) => Iterate(a, b, (a, b) => a + b);

  public static Diag operator *(Diag a, Diag b) => Iterate(a, b, (a, b) => a * b);

  private double Value(int i, int j) {
    if(Range(i, j)) throw new Exception(); 
    if (i == j) return x[i]; else return 0.0;
  }

  private void SetValue(int i, int j, double e) {
    if(Range(i, j)) throw new Exception();
    if(i == j) x[i] = e; else throw new Exception();
  }

  private bool Range(int i, int j) { return i < 0 || i > x.Length || j < 0 || j > x.Length; }

  private static Diag Iterate(Diag a, Diag b, Func<double, double, double> F) {
    if(a.x.Length != b.x.Length) throw new Exception();
    Diag result = new Diag(a.x.Length);
    for(int i = 0; i < result.x.Length; i++) { result.x[i] = F.Invoke(a.x[i], b.x[i]); }
    return result;
  }
}