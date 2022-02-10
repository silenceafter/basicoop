//задание 1
Console.WriteLine($"Высота одного этажа = { Building.HeightOfFloor } метра(ов)\n");
//1
var buildingOne = new Building(9, 0, 468, 13);//9 этажей, нет подземных этажей, 468 квартир в доме, 13 подъездов
if (buildingOne != null) 
{
    Show(buildingOne);
    ShowSample(buildingOne, 2);
    ShowSample(buildingOne, 9);
    Console.WriteLine();
}

//2
var buildingTwo = new Building(25, 2, 1500, 4);
if (buildingTwo != null)
{
    Show(buildingTwo);
    ShowSample(buildingTwo, 13);
    ShowSample(buildingTwo, 22);
    Console.WriteLine();
}

//3
var buildingThree = new Building(54, 4, 7500, 2);
if (buildingThree != null)
{
    Show(buildingThree);
    ShowSample(buildingThree, -5);
    ShowSample(buildingThree, -1);
    ShowSample(buildingThree, 78);
    ShowSample(buildingThree, 49);
    Console.WriteLine();
}
Console.ReadKey();

static void Show(Building building) 
{
    Console.WriteLine($"Номер здания = { building.Number }");
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

public class Building {
    public Building(uint floor, uint floorUnderground, uint apartment, uint entrance) {
        //генерируем номер здания
        IncreaseUniqueNumber();
        _number = Number;
        //        
        _floor = floor;
        _floorLiving = floor - floorUnderground;
        _floorUnderground = floorUnderground;
        _apartment = apartment;
        _entrance = entrance;
        _height = BuildingHeight();
    }

    private static uint _number = 0;//уникальный номер здания
    private double _height;//высота здания
    private uint _floor;//кол-во этажей
    private uint _floorLiving;//кол-во жилых этажей
    private uint _floorUnderground;//кол-во подземных этажей
    private uint _apartment;//кол-во квартир в доме
    private uint _entrance;//кол-во подъездов    
    private static double _heightOfFloor = 3.0;//высота одного этажа

    public uint Number {
        //номер здания
        get => _number;
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

    public static void IncreaseUniqueNumber() 
    {
        //получить уникальный номер здания
        _number = ++_number;
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
