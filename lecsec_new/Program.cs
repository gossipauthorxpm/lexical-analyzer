class Program
{
    public static void Main()
    {
        lecsec_new.Lecsic lecsic = new lecsec_new.Lecsic(@"D:\Шарага\lecsec_new\lecsec_new\text.txt");
        string str = lecsic.ReadFileToStr();
        Console.WriteLine(str);

        string[] delimeters = { ",", ";", "{", "}", "(", ")", "." };
        string[] constants = { "b", "10", "a" };
        string[] keywords = { "int", "if", "Console", "WriteLine" };
        string[] operators = { "=", ">", "<", "<=", ">=", "==", "!=" };

        string[] main_lecsem = { "=", ">", "<", "<=", ">=", "==", "!=", ",", ";", "{", "}", "(", ")", ".", "b", "10", "a", "int", "if", "Console", "WriteLine" };
        lecsic.Analyz(delimeters, constants, keywords, operators, str, main_lecsem);
    }
}