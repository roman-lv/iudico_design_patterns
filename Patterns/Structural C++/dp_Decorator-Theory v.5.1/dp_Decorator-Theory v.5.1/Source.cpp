#include <iostream>
#include <string>

using namespace std;

// Базовий клас автомобіля 
class Car
{
private:
	string privateBrandName;

protected:
	const string &getBrandName() const
	{
		return privateBrandName;
	}
	void setBrandName(const string &value)
	{
		privateBrandName = value;
	}
public:
	virtual void Go()
	{
		cout << string("I'm ") << getBrandName() << string(" and I'm on my way...") << endl;
	}
};

// Конкретна реалізація класу Car
class Mercedes : public Car
{
public:
	Mercedes()
	{
		setBrandName("Mercedes");
	}
};

// Втілення патерну Decorator - абстраткний клас для всіх класів Decorator
class DecoratorCar : public Car
{
private:
	Car * privateDecoratedCar;

protected:
	Car * getDecoratedCar() const
	{
		return privateDecoratedCar;
	}
	void setDecoratedCar(Car *value)
	{
		privateDecoratedCar = value;
	}
public:
	DecoratorCar(Car *decoratedCar)
	{
		setDecoratedCar(decoratedCar);
	}
	virtual void Go() override
	{
		getDecoratedCar()->Go();
	}
};

//«Декор» карети швидкої допомоги 
class AmbulanceCar : public DecoratorCar
{
public:
	AmbulanceCar(Car *decoratedCar) : DecoratorCar(decoratedCar)
	{
	}
	virtual void Go() override
	{
		DecoratorCar::Go();
		cout << string("... beep-beep-beeeeeep ...") << endl;
	}
};

void main()
{
	//Використання патерну 
	Car *doctorsDream = new AmbulanceCar(new Mercedes());
	doctorsDream->Go();
}