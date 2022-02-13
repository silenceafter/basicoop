//задание 2
using System;
using System.Collections;

//параметры зданий
var parameters = new uint[][] 
{ 
    new uint[] {9, 0, 468, 13 },//здание 1
    new uint[] { 25, 2, 1500, 4 },//здание 2
    new uint[] { 54, 4, 7500, 2 }//здание 3
};

Hashtable ht = Creator.CreateBuild(parameters);
ICollection keys = ht.Keys;
//
ShowHashtable(ht, keys);               

uint number = 3;
Console.WriteLine($"Удаляем здание { number }\n");
//
Creator.Delete(ht, number);
keys = ht.Keys;
//
ShowHashtable(ht, keys);  
Console.ReadKey();

static void Show(Building building) 
{
    Console.WriteLine($"Номер здания = { building.Id }");
    Console.WriteLine($"Кол-во этажей всего = { building.Floor }");
    Console.WriteLine($"Кол-во жилых этажей = { building.FloorLiving }");
    Console.WriteLine($"Кол-во подземных этажей = { building.FloorUnderground }");
    Console.WriteLine($"Кол-во квартир в доме = { building.Apartment }");
    Console.WriteLine($"Кол-во подъездов = { building.Entrance }");
    Console.WriteLine($"Кол-во квартир в подъезде = { building.NumberOfApartmentsInTheEntrance() }");
    Console.WriteLine($"Кол-во квартир на этаже = { building.NumberOfApartmentsPerFloor() }");
    Console.WriteLine($"Высота здания = { building.Height } метра(ов)");
    Console.WriteLine();
}

static void ShowSample(Building building, int floor) 
{
    Console.WriteLine($"Высота { floor } этажа = { building.FloorHeight(floor) } метра(ов)");
}

static void ShowHashtable(Hashtable ht, ICollection keys)
{
    foreach (uint key in keys) 
    {
        var building = (Building?)ht[key];
        if (building != null)
        {
            Show(building);
        }
    }
}

public class Building {
    public Building(uint floor, uint floorUnderground, uint apartment, uint entrance) {
        //генерируем номер здания
        IncreaseId();
        _id = _cnt;
        //        
        _floor = floor;
        _floorLiving = floor - floorUnderground;
        _floorUnderground = floorUnderground;
        _apartment = apartment;
        _entrance = entrance;
        _height = BuildingHeight();
    }

    private static uint _cnt = 0;//счетчик номеров здания
    private uint _id;//уникальный номер здания
    private double _height;//высота здания
    private uint _floor;//кол-во этажей
    private uint _floorLiving;//кол-во жилых этажей
    private uint _floorUnderground;//кол-во подземных этажей
    private uint _apartment;//кол-во квартир в доме
    private uint _entrance;//кол-во подъездов    
    private static double _heightOfFloor = 3.0;//высота одного этажа

    public uint Id {
        //номер здания
        get => _id;
    }

    public double Height
    {
        //высота здания
        get => _height;
    }

    public uint Floor
    {
        //кол-во этажей
        get => _floor;
    }

    public uint FloorLiving
    {
        //кол-во жилых этажей
        get => _floorLiving;
    }

    public uint FloorUnderground
    {
        //кол-во подземных этажей
        get => _floorUnderground;
    }

    public uint Apartment
    {
        //кол-во квартир
        get => _apartment;
    }

    public uint Entrance
    {
        //кол-во подъездов
        get => _entrance;
    }

    public static double HeightOfFloor
    {
        //высота одного этажа
        get => _heightOfFloor;
    }    

    public static void IncreaseId() 
    {
        //получить уникальный номер здания
        _cnt = ++_cnt;
    }

    public double FloorHeight(int floorNumber) 
    {
        //узнать высоту этажа
        double result = 0;
        try {
            if (floorNumber < 0) {
                //подземные этажи
                var floorAbs = Math.Abs(floorNumber);
                if (floorAbs > 0 && floorAbs <= _floorUnderground)
                {
                    result = _heightOfFloor * floorNumber;
                }
            } else if (floorNumber > 0 && floorNumber <= _floorLiving) {
                //жилые этажи
                result = _heightOfFloor * floorNumber;
            } else {
                //ошибка, значение больше или меньше требуемого
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        return result;
    }

    public double BuildingHeight()
    {
        //высота здания
        return Convert.ToDouble(_floorLiving * Building.HeightOfFloor);
    }

    public uint NumberOfApartmentsInTheEntrance()
    {
        //вычислить количество квартир в подъезде
        return _apartment / _entrance;
    }

    public uint NumberOfApartmentsPerFloor()
    {
        //вычислить количество квартир на этаже
        return NumberOfApartmentsInTheEntrance() / _floor;
    }
}

public class Creator 
{
    private Hashtable _ht = new Hashtable();

    public Hashtable Ht 
    {
        get => _ht;
        set => _ht = value;
    }

    private Creator()
    {
    }

    public static Hashtable CreateBuild(uint[][] values)
    {
        var creator = new Creator();
        if (creator != null)
        {
            foreach(var value in values)
            {
                uint floor = value[0];
                uint floorUnderground = value[1];
                uint apartment = value[2];
                uint entrance = value[3];
                
                var ht = creator.Ht;
                var building = new Building(floor, floorUnderground, apartment, entrance);
                if (building != null) 
                {
                    Add(creator, building);
                }            
            }
            return creator.Ht;
        }
        return new Hashtable();
    }

    public static bool Add(Creator creator, Building building)
    {
        //добавить производный объект в хэш-таблицу 
        if (building != null && creator != null)
        {
            var ht = creator.Ht;
            if (!Find(ht, building.Id))
            {                
                ht.Add(building.Id, building);
                return true;
            }
        }
        return false;
    }

    public static bool Delete(Hashtable ht, uint id)
    {
        //удалить объект из хэш-таблицы
        if (Find(ht, id))
        {
            ht.Remove(id);
            return true;
        }
        return false;
    }

    public static bool Find(Hashtable ht, uint id)
    {
        return ht.ContainsKey(id);
    }
}

