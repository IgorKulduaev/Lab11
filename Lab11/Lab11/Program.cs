Console.Write("Введите фамилию: ");
string surname = Console.ReadLine()!;
Console.Write("Введите средний балл: ");
int midball = int.Parse(Console.ReadLine()!);
Console.Write("Введите курс: ");
int kurs = int.Parse(Console.ReadLine()!);

Student kabel1 = new Student(surname, midball, kurs);
Console.WriteLine(kabel1);
Console.WriteLine(kabel1.GetHashCode());
Console.Write("английский язык присутствует? 1-да, 2-нет: ");
bool eng = (int.Parse(Console.ReadLine()!) == 1 ? true : false);

engStudent kabel2 = new engStudent(surname, midball, kurs, eng);
Console.WriteLine(kabel2);
Console.WriteLine(kabel2.GetHashCode());

class Student
{
    private string? surname;
    private int midball;
    private int kurs;
    public Student(string? _surname, int _midball, int _kurs)
    {
        this.surname = _surname;
        this.midball = _midball;
        this.kurs = _kurs;
    }
    public string? Surname
    {
        get { return surname; }
        set { surname = value; }
    }
    public int Midball
    {
        get { return midball; }
        set { if (value > 0) midball = value; }
    }
    public int Kurs
    {
        get { return kurs; }
        set { if (value > 0) kurs = value; }
    }

    public virtual double Quality()
    {
        return 0.2*midball*kurs;
    }

    public override string? ToString()
    {
        return $"фамилия: {surname}, средний балл: {midball}, курс: {kurs}, качество: {Quality()}"; 
    }
}

class engStudent : Student
{
    public bool eng;

    public engStudent(string? _surname, int _midball, int _kurs, bool _eng) : base(_surname, _midball, _kurs)
    {
        eng = _eng;
    }
    public bool Eng
    {
        get { return eng; }
        set { eng = value; }
    }

    public override double Quality()
    {
        if (eng) return 2 * base.Quality();
        return 0.9 * base.Quality();
    }

    public override string? ToString()
    {
        return $"Студент по фамилии {Surname}, cо средним баллом {Midball}," + (eng ? " с английским языком," : "") +
            $" курсом {Kurs} имеет качество:{Quality():F2}";
    }
}

