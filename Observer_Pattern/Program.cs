using System;

Console.WriteLine("Hello, Guys! Salary Imcreament");

Salary salary = new Salary();

new ManagerBonus(salary);
new EmployeeBonus(salary);
new DierctorBonus(salary);

salary.Val = 230000;

Console.ReadLine();


class Salary
{
    List<Observer> observers = new List<Observer>();

    public void attach(Observer obj)
    {
        observers.Add(obj);
    }
    private int val;
    public int Val
    {
        set
        {
            val = value;
            notifyAllObservers();
        }
        get
        {
            return this.val;
        }
    }

    private void notifyAllObservers()
    {
        foreach (Observer ob in observers)
        {
            ob.update();
        }
        Console.WriteLine("This is how things happpend");
    }
}

abstract class Observer
{
    protected Salary sal;
    public abstract void update();
}

class EmployeeBonus : Observer
{
    public EmployeeBonus(Salary sal)
    {
        this.sal = sal;
        this.sal.attach(this);
    }

    public override void update()
    {
        Console.WriteLine("Employee Bonus is " + string.Format("{0:###,###.00}", (sal.Val * 2)));
    }
}

class  ManagerBonus : Observer
{
    public ManagerBonus(Salary sal)
    {
        this.sal = sal;
        this.sal.attach(this);
    }

    public override void update()
    {
        Console.WriteLine("Manager Bonus is " + string.Format("{0:###,###.00}", (sal.Val * 3)));
    }
}

class DierctorBonus : Observer
{
    public DierctorBonus(Salary sal)
    {
        this.sal = sal;
        this.sal.attach(this);
    }

    public override void update()
    {
        Console.WriteLine("Dierctor Bonus is " + string.Format("{0:###,###.00}", (sal.Val * 5)));
    }
}

