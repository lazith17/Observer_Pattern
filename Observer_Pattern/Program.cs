using System;

Console.WriteLine("Hello, Guys! Salary Imcreament");

Salary salary = new Salary();

new ManagerBonus(salary);
new EmployeeBonus(salary);

salary.Val = 3000;

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
    }
}

abstract class Observer
{
    protected Salary sal;
    public abstract void update();
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
        Console.WriteLine("Manager Bonus is " + (sal.Val * 3));
    }
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
        Console.WriteLine("Employee Bonus is " + (sal.Val * 2));
    }
}
